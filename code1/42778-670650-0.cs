    System.Timers.Timer _WaitForScheduledTime;
    _WaitForScheduledTime = new System.Timers.Timer();
    _WaitForScheduledTime.Elapsed += new ElapsedEventHandler(WaitForScheduledTime_OnElapsed);
    _WaitForScheduledTime.Interval = _ListOfJobs.IntervalUntilFirstJobIsToRun().TotalMilliseconds;
    _WaitForScheduledTime.Start();
...
    private void WaitForScheduledTime_OnElapsed(object source, EventArgs e)
    {
        log.Debug("Ready to run at least one job");
        // restart the timer
        _WaitForScheduledTime.Interval = _ListOfJobs.IntervalUntilFirstJobIsToRun().TotalMilliseconds;
        _WaitForScheduledTime.Start();
    }
