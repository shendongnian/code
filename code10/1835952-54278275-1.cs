    void Start()
    {
        rigidbody2DComponent = GetComponent<Rigidbody2D>();
        initialYPosition = transform.position.y;
        Move();
    }
    void Move()
    {
        speed = Random.Range(-10, -20);
        rigidbody2DComponent.velocity = new Vector2(0, speed);
        //keep track of the old x position
        initialXPosition = transform.position.x;
        //store the new x position
        newXPosition = initialXPosition;
        //new x position cannot be the same as the old x position
        while (Mathf.Abs(newXPosition - initialXPosition) < 1)
        {
            newXPosition = Random.Range(-6f, 6f);
        }
        transform.position = new Vector3(newXPosition, initialYPosition, transform.position.z);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "resetWall")
        {
            //Lets let our master script take care of spawning
            Enemy.SpawnEnemy.Spawn();
            //Let's let our master script handle this
            //Without changing the name, the original name will get a bunch of
            //(clone) added to it as it respawns
            //newEnemyObject.name = "newEnemy";
            //newEnemyObject.tag = "Enemy";
            //Destroy the old enemy
            Destroy(gameObject);
        }
    }
