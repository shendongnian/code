    bool collided = false;
    
    void OnMouseUp()
    {
        if (collided)
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
