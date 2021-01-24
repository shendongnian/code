    // set e.g. in the inspector
    public float verticalMoveSpeed;
    // ...
    if (Input.GetKey(KeyCode.UpArrow)) 
    { 
        rb.MovePosition(transform.position + Vector3.up * verticalMoveSpeed * Time.deltaTime);
    }
    
    if (Input.GetKey(KeyCode.DownArrow)) 
    { 
        rb.MovePosition(transform.position - Vector3.up * verticalMoveSpeed * Time.deltaTime);
    }
