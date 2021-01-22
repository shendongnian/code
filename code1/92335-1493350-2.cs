    // using System.Timers;
    private void myMethod()
    {
        var timer = new Timer { 
            AutoReset = false, Interval = getMillisecondsToNextAlarm() };
        timer.Elapsed += (src, args) =>
        {
            // Do timer handling here.
            timer.Interval = getMillisecondsToNextAlarm();
            timer.Start();
        };
        timer.Start();
    }
    private double getMillisecondsToNextAlarm()
    {
        // This is an example of making the alarm go off at every "o'clock"
        var now = DateTime.Now;
        var inOneHour = now.AddHours(1.0);
        var roundedNextHour = new DateTime(
            inOneHour.Year, inOneHour.Month, inOneHour.Day, inOneHour.Hour, 0, 0);
        return (roundedNextHour - now).TotalMilliseconds;
    }
