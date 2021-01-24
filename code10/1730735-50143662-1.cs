    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class Gun : MonoBehaviour
    {
    public Transform bulletCapTransform;
    public GameObject bulletCap;
    public float ammo;
    public float magAmmo;
    public GameObject shootEffect;
    public Transform bulletTransform;
    public GameObject bullet;
    public float bulletForce;
    public GameObject crossHair;
    public float fireRate = 0.3333f;
    private float timeStamp;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
       Shoot();
       Aim();
    }
    public void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 50, 25), magAmmo + " / " + ammo);
    }
    public void Shoot()
    {
        if (Time.time >= timeStamp && Input.GetButton("Fire1") && magAmmo > 0)
        {
            Debug.Log("shoot");
            GameObject bulletCapInstance;
            bulletCapInstance = Instantiate(bulletCap, bulletCapTransform.transform.position, bulletCapTransform.rotation) as GameObject;
            bulletCapInstance.GetComponent<Rigidbody>().AddForce(bulletCapTransform.right * 10000);
           
            //This will send a raycast straight forward from your camera centre.
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            //check for a hit
            if (Physics.Raycast(ray, out hit))
            {
                // take the point of collision (make sure all objects have a collider)
                Vector3 colisionPoint = hit.point;
                //Create a vector for the path of the bullet from the 'gun' to the target
                Vector3 bulletVector = colisionPoint - bullet.transform.position;
                GameObject bulletInstance = Instantiate(bullet, bulletTransform) as GameObject;
                //See it on it's way
                bulletInstance.GetComponent<Rigidbody>().AddForce(bulletVector * bulletForce);
            }
            Instantiate(shootEffect, bulletTransform);
            timeStamp = Time.time + fireRate;
            magAmmo = magAmmo - 1;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //This is just for testing
            magAmmo = magAmmo + 10;
        }
    }
    void Aim()
    {
        if (Input.GetButton("Fire2"))
        {
            anim.SetBool("Aiming", true);
            crossHair.SetActive(false);
        }
        else
        {
            anim.SetBool("Aiming", false);
            crossHair.SetActive(true);
        }
    }
    }
