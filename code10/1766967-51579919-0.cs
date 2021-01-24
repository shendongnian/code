    public void WaitThisTimeAndHideMiniButton1(int givenTime)
    {
        if(_myTimerForButtonA != null && _myTimerForButtonA.Enabled)
        {
             _myTimerForButtonA.Stop();
        }
        _myTimerForButtonA = new System.Windows.Forms.Timer();
        _myTimerButtonA.Tick += new EventHandler(TimerEventProcessorForForButtonA);
        _myTimerForForButtonA.Interval = givenTime;
        _myTimerForForButtonA.Start();
    }
