    private Action onCompleted;
    private void CountdownTimer(int Duration, string Prefix, string Suffix, Action callback)
    {
        Countdown = new DispatcherTimer();
        Countdown.Tick += new EventHandler(Countdown_Tick);
        Countdown.Interval = new TimeSpan(0, 0, 1);
        CountdownTime = Duration;
        CountdownPrefix = Prefix;
        CountdownSuffix = Suffix;
        Countdown.Start();
        this.onCompleted = callback;
    }
    ...
        else
        {
            Countdown.Stop();
            Action temp = this.onCompleted; // thread-safe test for null delegates
            if (temp != null)
            {
                temp();
            }
        }
    
