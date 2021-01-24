    bool isLaunching;
     // instead of your Update
    void OnMouseUp() 
    {
        // makes sure you can only launch after updating startpos
        if(!isLaunching) return;
                
        endpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        LaunchBall();
        isLaunching = false;
    }
    void OnMouseDown()
    {
        startpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isLaunching = true;
    }
