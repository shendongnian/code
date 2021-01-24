    void Start() // or could go in the Awake() method depending on your game
    {
        GetComponent<Rigidbody>().enabled = false;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().enabled = true;
        }
    }
    
    // When respawning, disable the Rigidbody.
