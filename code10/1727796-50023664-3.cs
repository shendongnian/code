    public float speed = 100;
    //Assign bulletPrefab from the Editor
    public GameObject bulletPrefab;
    //Assign ship from the Editor
    public Transform spaceShip;
    
    //[Empty GameObject] Assign from the Editor
    public Transform leftBarrel;
    //[Empty GameObject] Assign from the Editor
    public Transform rightBarrel;
    
    
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //Instantiate left and right bullets
            GameObject leftBullet = Instantiate(bulletPrefab, leftBarrel.position, spaceShip.rotation);
            GameObject rightBullet = Instantiate(bulletPrefab, rightBarrel.position, spaceShip.rotation);
    
            //Shoot left and right bullets
            ShootBullet(leftBullet);
            ShootBullet(rightBullet);
        }
    }
    
    void ShootBullet(GameObject obj)
    {
        Rigidbody2D bulletRb = obj.GetComponent<Rigidbody2D>();
    
        //The direction to shoot the bullet
        Vector3 pos = spaceShip.up * speed;
        //Shoot
        bulletRb.velocity = pos;
    }
