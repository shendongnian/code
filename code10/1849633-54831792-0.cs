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
            // Places the ball at the player's current position.
            transform.Translate(-player.transform.forward);
            rb.AddForce(-player.transform.forward * power);
        }
    }
