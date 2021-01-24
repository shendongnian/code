        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        { 
            StopAllCoroutines();
            StartCoroutine(MoveVertical(2.0f, verticalMoveSpeed));
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow)) 
        { 
            StopAllCoroutines();
            StartCoroutine(MoveVertical(-2.0f, verticalMoveSpeed));
        }
