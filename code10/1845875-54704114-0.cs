    public TimerTest2()
    {
        _timer = new Timer(DoWork);
        _timer.Change(0, Timeout.Infinite);
    }
