    Point lastPoint;
    const float tolerance = 5.0;
    //you might want to replace this with event subscribe/unsubscribe instead
    bool listening = false;
    void OnMouseOver()
    {
        lastpoint = Mouse.Location;
        timer.Start();
        listening = true; //listen to MouseMove events
    }
    void OnMouseLeave()
    {
        timer.Stop();
        listening = false; //stop listening
    }
    void OnMouseMove()
    {
        if(listening)
        {
            if(Math.abs(Mouse.Location - lastPoint) > tolerance)
            {
                //mouse moved beyond tolerance - reset timer
                timer.Reset();
                lastPoint = Mouse.Location;
            }
        }
    }
    void timer_Tick(object sender, EventArgs e)
    {
        //mouse "stopped moving"
    }
