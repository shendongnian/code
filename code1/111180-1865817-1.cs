    public class TimerEnableFlag
    {
        public bool IsTimerEnabled{get; set;}
    }
    public class TimerEnabler : IDisposable
    {
       private TimerEnableFlag flag;
    
       public TimerEnabler(TimerEnableFlag flag)
       {
           this.flag = flag;
           flag.IsTimerEnabled = true;
       }
      
       public void Dispose()
       {
          flag.IsTimerEnabled = false;
       }
    }
