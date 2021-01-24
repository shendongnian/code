    // set e.g. in the inspector
    public float verticalMoveSpeed;
    
    // ...
    
    if (Input.GetKeyDown(KeyCode.UpArrow)) 
    { 
        StartCoroutine(MoveVertical(2.0f, verticalMoveSpeed));
    } 
    else if (Input.GetKeyDown(KeyCode.DownArrow)) 
    { 
        StartCoroutine(MoveVertical(-2.0f, verticalMoveSpeed));
    }
    // ...
    
    private IEnumerator MoveVertical(float distance, float speed)
    {
        var movedDistance = 0.0f;
        var originalY = transform.position.y;
    
        while(movedDistance < distance)
        {
            rb.MovePosition(transform.position + Vector3.up * speed * Time.deltaTime);
    
            yield return null;
        }
    
        // make sure you didn't move to much on Y
        rb.MovePosition(new Vector3(transform.position.x, originalY + distance, transform.position,z));
    }
