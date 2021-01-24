    public bool useWorldSpace;
    public Rigidbody rb;
    public float speed = 18;
    
    public void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
    
        //Movement
        Vector3 tempVect = new Vector3(0, 0, v);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
    
        if (useWorldSpace)
            tempVect = transform.position + tempVect;
        else
            tempVect = transform.position + transform.TransformDirection(tempVect);
    
    
        rb.MovePosition(tempVect);
    
        //Rotation
        Vector3 angle = new Vector3(0, 100, 0);
        Quaternion deltaRot = Quaternion.Euler(angle * h * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRot);
    }
