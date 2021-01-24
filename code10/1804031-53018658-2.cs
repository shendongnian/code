    public float speed;
    public float stoppingDistance;
    private Transform target;
    Player Player;
    
    enum Direction
    {
        right = 1,
        left = -1;
    }
    
    private Vector3 originalScale;
    
    private void Start()
    {
        Player = GameObject.Find("Axel").GetComponent<Player>();
        // If you just want the transform of the Player
        // than simply use 
        target = Player.transform;
        // instead of
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    
        originalScale = transform.localScale;
    }
    
    // Btw: for reacting to any user input (as the player movement)
    // it is always better to do these things
    // in LateUpdate instead of Update
    // LateUpdate is executed after all Update calls in the Scene finished
    void LateUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    
            if (Player.facingRight == false)
            {
                Turn(left);
            }
            else if (Player.facingRight == true)
            {
                Turn(right);
            }
        }
    }
    void Turn(Direction direction)
    {
        transform.localScale = originalScale * (float)direction;
    }
