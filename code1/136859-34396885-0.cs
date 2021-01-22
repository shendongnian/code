    public class TimeDependentClass
    {
        public void TimeDependentMethod(DateTime someTime)
        {
            if (GetCurrentTime() > someTime) DoSomething();
        }
    
        protected virtual DateTime GetCurrentTime()
        {
            return DateTime.Now; // or UtcNow
        }
    }
