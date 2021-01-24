    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueDialog();
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OtherMethod();
        }
    
    }
