using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float range;
    [SerializeField] float maxDistance;
    [SerializeField] GameObject effect;

    Vector2 wayPoint;

    Shoot shoot;

    // Start is called before the first frame update
    void Start()
    {
        shoot = FindObjectOfType<Shoot>();
        SetNewDestination();
        speed = Random.Range(5f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }

        if(gameObject.transform.position.y <= -4)
        {
            Destroy(gameObject);
        }

    }

    /*
    private void OnMouseDown()
    {
        shoot.Shooting();
        Instantiate(effect, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        GameManager.instance.increasePoint();
        HealthManager.instance.Heal(7);
        Destroy(gameObject, 0.5f);
    }
    */

    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(effect, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        GameManager.instance.increasePoint();
        HealthManager.instance.Heal(7);
        Destroy(gameObject, 0.5f);
    }

    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }

}
