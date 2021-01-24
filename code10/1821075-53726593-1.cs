    public void FixedUpdate () {
    
        if(MoveCamera == true){
    
           Vector3 desiredPosition = new Vector3(0, Ball.position.y + offset.y, Ball.position.z + offset.z);
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
            transform.position = SmoothedPosition;
        }
    
    
        if (transform.position.z >= 2f)
        {
            MoveCamera = false;
        }
    }
