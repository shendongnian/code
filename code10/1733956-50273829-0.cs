    public Camera cam; // Initialize this in Awake/Start!    
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 desiredDirection = cam.transform.forward * y + cam.transform.right * x;
        // rb.AddForce(desiredDirection * speed);
    }
