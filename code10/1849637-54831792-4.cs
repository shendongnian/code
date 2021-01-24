    private void Start()
    {
        player = GameObject.Find("Whyareyoulikethis");
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            power += 10;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            // Places the ball at the player's current position
            transform.position = player.transform.position;
            // you don't want to translate it but set it to the players position here
            rb.AddForce(-player.transform.forward * power);
        }
    }
