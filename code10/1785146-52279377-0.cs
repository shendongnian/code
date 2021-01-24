    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int count = 1;
            while(count < <desired number of iterations>){
                ContinueDialog();
                Cursor.lockState = CursorLockMode.Locked;
                count++;
            }
        }
    }
