    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int count = 1;
            while(count < <desired number of iterations>)
            {
                switch(count)
                {
                    case 1: 
                        ContinueDialog();
                        Cursor.lockState = CursorLockMode.Locked;
                        count++;
                        break;
                    case 2: 
                        otherFunction();
                        count++;
                        break;
                    case 3: 
                        thirdFunction();
                        count++;
                        break;
                }
            }   
        }
    }
