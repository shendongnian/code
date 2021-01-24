    void Update()
    {
    
        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");
    
        Vector3 translation = new Vector3(h, 0, v);
        translation *= moveSpeed * Time.deltaTime;
    
        transform.Translate(translation, Space.World);
    
    
        if (v == 1)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }
