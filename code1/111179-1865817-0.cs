    public class TimerEnableFlag
    {
        public bool IsTimerEnabled{get; set;}
    }
    public class TimerEnabler : IDisposable
    public TimerEnabler(TimerEnableFlag flag)
    {
        flag.IsTimerEnabled = true;
    }
    public void Dispose()
    {
        flag.IsTimerEnabled = false;
    }
