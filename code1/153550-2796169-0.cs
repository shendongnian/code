    TimeSpan FrameInterval =  TimeSpan.FromMillis(1000.0/60.0);
    DateTime PrevFrameTime = DateTime.MinValue;
    while(true)
    {
        DateTime CurrentFrameTime = DateTime.Now;
        TimeSpan diff = DateTime.Now - PrevFrameTime;
        if(diff < FrameInterval)
        {
            DrawScene();
            PrevFrameTime = CurrentFrameTime;
        }
        else
        {
            Thread.Sleep(FrameInterval - diff);
        }
    }
