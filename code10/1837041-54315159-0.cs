    public Vector3 Max;
    public Vector3 Min;
    
    
        void FixedUpdate()
        {  
            Vector3 desiredPosition;
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                desiredPosition = transform.position + transform.up;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                desiredPosition = transform.position + transform.up * -1;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                desiredPosition = transform.position + transform.right * -1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                desiredPosition = transform.position + transform.right;
            }
    
    	    desiredPosition = Vector3.Min(desiredPosition, this.Min);
    	    desiredPosition = Vector3.Max(desiredPosition, this.Max);
    
    	    rb.MovePosition(desiredPosition);	
        }
