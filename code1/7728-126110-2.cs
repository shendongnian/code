    using System;
    using System.Threading;
    using System.Configuration;    
    public class ServiceEventHandler
    {
        Timer _timer;
        public ServiceEventHandler()
        {
            // get configuration etc.
            _timer = new Timer(
                new TimerCallback(EventTimerCallback)
                , null
                , Timeout.Infinite
                , Timeout.Infinite);
        }
        private void EventTimerCallback(object state)
        {
            // do something
        }
        public void StartEventLoop()
        {
            // wait a minute, then run every 30 minutes
            _timer.Change(TimeSpan.Parse("00:01:00"), TimeSpan.Parse("00:30:00");
        }
    }
        
