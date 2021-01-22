    sealed class TimerWrapper : IDisposable
    {
        readonly Timer timer;
    
        object State { get; set; }
    
        public TimerWrapper(TimerCallback callback) 
        {
            timer = new Timer(delegate { callback(State); });
        }
    
        public void Change(object state, TimeSpan dueTime, TimeSpan period)
        {
            timer.Change(dueTime, period);
            State = state;
        }
    
        public void Dispose()
        {
            timer.Dispose();
        }
    }
