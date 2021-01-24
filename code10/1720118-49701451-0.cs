    GameObject bulletPrefab;
    Transform cameraTransform;
    public float bulletSpeed = 300;
    
    private void Start()
    {
        //Load Prefab
        bulletPrefab = Resources.Load<GameObject>("Enemy/Bullet");
    
        //Get camera transform
        cameraTransform = Camera.main.transform;
    }
    
    void Update()
    {
        //Shoot bullet when space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootBullet();
        }
    }
    
    void shootBullet()
    {
        //Instantiate prefab
        GameObject tempObj = Instantiate(bulletPrefab) as GameObject;
    
        //Set position of the bullet in front of the player
        tempObj.transform.position = transform.position + cameraTransform.forward;
    
        //Get the Rigidbody that is attached to that instantiated bullet
        Rigidbody projectile = GetComponent<Rigidbody>();
    
        //Shoot the Bullet 
        projectile.velocity = cameraTransform.forward * bulletSpeed;
    }
