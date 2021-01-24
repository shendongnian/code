    bool collided = false;
    
    void Update()
    {
        if ((Input.GetMouseButton(0)) && collided)
        {
            Debug.Log("Collding while mouse is up");
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        collided = true;
    }
    
    void OnCollisionExit(Collision collision)
    {
        collided = false;
    }
