    void Update()
    {
    	if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Shift Pressed"); //Logs message to the Unity Console.
            shiftOn = true;
        }
    
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("Shift Released"); //Logs message to the Unity Console.
            shiftOn = false;
        }
    }
