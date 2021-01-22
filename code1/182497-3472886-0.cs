        public bool WaitFor(Action action, TimeSpan timeout)
        {
            var waitHandle = new AutoResetEvent(false);
            ThreadPool.QueueUserWorkItem(state =>
            {
                action();
                waitHandle.Set();
            });
            return waitHandle.WaitOne(timeout);
        }
