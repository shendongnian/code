    public void FixedUpdate () {
    
        if(MoveCamera == true){
    
            float desiredPosition = new Vector3(Ball.position.x, Ball.position.y, Ball.position.z + offset.z);
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
            transform.position = SmoothedPosition;
        }
    
    
        if (transform.position.z >= 2f)
        {
            MoveCamera = false;
        }
    }
