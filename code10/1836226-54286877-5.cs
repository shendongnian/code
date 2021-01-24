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
        var originalY = transform.position.y;
        var targetY = originalY + distance;
        var currentY = originalY; 
        do
        {     
            rb.MovePosition(new Vector 3(transform.position.x, currentY, transform.positiom.z);
    
            // Update currentY to the next Y position
            currentY = Mathf.Clamp(currentY + speed * Time.deltaTime, originalY, targetY);
            yield return null;
        }
        while(currentY < originalY);
    
        // make sure you didn't move to much on Y
        rb.MovePosition(new Vector3(transform.position.x, targetY, transform.position,z));
    }
