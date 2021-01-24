    Rigidbody _rigidbody;    
    
    void Start() // or could go in the Awake() method depending on your game
    {
        _rigidbody = GetComponent<Rigidbody>();
        TogglePhysics(false);
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TogglePhysics(true);
        }
    }
    
    void TogglePhysics(bool isEnabled)
    {
        // IsKinematic needs to be true to disable physics. See the documentation for IsKinematic.
        _rigidbody.IsKinematic = !isEnabled; 
        _rigidBody.detectCollisions = isEnabled;
    }
    
    // When respawning, disable the Rigidbody.
