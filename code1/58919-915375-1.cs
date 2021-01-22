    public event EventHandler TimerElapsed
    {
        add { timer.Elapsed += value; }
        remove { timer.Elapsed -= value; }
    }
