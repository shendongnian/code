    void Update()
    {
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool keyPressed = Input.GetKeyUp( /* other key code here */ );
        if(shiftPressed && keyPressed)
        {
            //Do logic here
        }
    }
