    void Update()
    {
        if (transform.hasChanged)
        {
            if (transform.position.x < lastXVal)
            {
                Debug.Log("Decreased!");
                //Update lastXVal
                lastXVal = transform.position.x;
            }
    
            else if (transform.position.x > lastXVal)
            {
                Debug.Log("Increased");
    
                //Update lastXVal
                lastXVal = transform.position.x;
            }
    
            transform.hasChanged = false;
        }
    }
