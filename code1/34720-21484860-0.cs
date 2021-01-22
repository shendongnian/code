        private static volatile List<System.Threading.Timer> _timers = new List<System.Threading.Timer>();
        public static void SetTimeout(Action action, int delayInMilliseconds)
        {
            System.Threading.Timer timer = null;
            var cb = new System.Threading.TimerCallback((state) =>
            {
                lock (_timers) 
                    _timers.Remove(timer); 
                timer.Dispose();
                action(); 
            });
            lock (_timers)
                _timers.Add(timer = new System.Threading.Timer(cb, null, delayInMilliseconds, System.Threading.Timeout.Infinite));
        }
            
