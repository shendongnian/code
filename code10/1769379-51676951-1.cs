    public float uiStartTime = 0;
    public float uiMaxTime = 15f;
    private bool timerRunning = false;
    
    private void Update()
    {
        //Increment timer if it's running
        if (timerRunning)
            uiStartTime += Time.deltaTime;
    
        TouchPhase touchPhase;
    
        if (ScreenTouched(out touchPhase))
        {
            //Check for keypres and start timer if it's not running
            if (touchPhase == TouchPhase.Ended && !timerRunning)
            {
                timerRunning = true;
            }
    
            //If the user touches the screen before the 15 seconds, then restart the timer.
            else if (touchPhase == TouchPhase.Ended && timerRunning && uiStartTime < uiMaxTime)
            {
                uiStartTime = 0f;
                Debug.Log("Timer Reset");
            }
        }
    
        //If the user hasn't touched the screen again and it has been 15 seconds then do something.
        if (uiStartTime >= uiMaxTime)
        {
            // Do Something
            Debug.Log("Timer not touched for 15 seconds");
        }
    }
