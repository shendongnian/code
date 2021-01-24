    public float speed = 100;
    //Assign from the Editor
    public GameObject bulletPrefab;
    
    
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            ShootBullet(bullet);
        }
    }
    
    void ShootBullet(GameObject rb)
    {
        Rigidbody2D bulletRb = rb.GetComponent<Rigidbody2D>();
    
        //The direction to shoot the bullet
        Vector3 pos = bulletRb.transform.forward * speed;
        //Shoot
        bulletRb.velocity = pos;
    }
