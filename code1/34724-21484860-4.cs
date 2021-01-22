    private static volatile List<System.Threading.Timer> _timers = new List<System.Threading.Timer>();
            private static object lockobj = new object();
            public static void SetTimeout(Action action, int delayInMilliseconds)
            {
                System.Threading.Timer timer = null;
                var cb = new System.Threading.TimerCallback((state) =>
                {
                    lock (lockobj)
                        _timers.Remove(timer);
                    timer.Dispose();
                    action()
                });
                lock (lockobj)
                    _timers.Add(timer = new System.Threading.Timer(cb, null, delayInMilliseconds, System.Threading.Timeout.Infinite));
    }
