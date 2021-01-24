    void Update()
        {
        
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OtherMethod();
                ContinueDialog();
                Cursor.lockState = CursorLockMode.Locked;
            }
       
        }
