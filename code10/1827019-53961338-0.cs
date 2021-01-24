    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class DroneShoot: MonoBehaviour
    {
    public Transform bulletspawn;
    public Rigidbody2D bulletPrefab;
    public float bulletSpeed = 750;
    public float bulletDelay;
    private Transform player;
    private Rigidbody2D clone;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("spieler").GetComponent<Transform>();
        StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(bulletDelay);
        if (Vector3.Distance(player.transform.position, bulletspawn.transform.position) < 20)
        {
            Vector3 difference = player.position - bulletspawn.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            bulletspawn.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            clone = Instantiate(bulletPrefab, bulletspawn.position, bulletspawn.rotation);
            clone.AddForce(bulletspawn.transform.right * bulletSpeed);
            StartCoroutine(Attack());
        }
    }
    }
