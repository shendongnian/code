        privtae bool isMovingVertical;
    
        // ...
    
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isMovingVertical ) 
        { 
            StartCoroutine(MoveVertical(2.0f, verticalMoveSpeed));
        } 
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !isMovingVertical ) 
        { 
            StartCoroutine(MoveVertical(-2.0f, verticalMoveSpeed));
        }
    
        // ...
    
        private IEnumerator MoveVertical(float distance, float speed)
        {
            isMovingVertical = true;
    
            // ...
    
            isMovingVertical = false;
        }
