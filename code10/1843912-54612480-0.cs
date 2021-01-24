`C#
    public void SystemEventLoggerTimer(System.Timers.Timer timer)
    {
        SysEvntLogFileChckTimerRun = true;
        timer.Elapsed += new ElapsedEventHandler(CheckFileOverflow);
        timer.Start();
    }
`
Calling code:
`C#
    var timer = new System.Timers.Timer() { Interval = 1000 * 60 * 60 };
    SystemEventLoggerTimer(timer);
`
Cancellation code (in cancel button's event handler, etc):
`C#
    timer.Stop();
`
