    private void Update()
    {
        if (textActive && !stopText)
        {
            KeyText("On");
            objectToEnable4.SetActive(true);
            stopText = true;
            Invoke("MyDelay", 2);
        }
    }
    private void MyDelay()
    {
        if (stopText) 
        {
            objectToEnable4.SetActive(false);
        }
    }
