    public class DelayedAction<T>
    {
        private SynchronizationContext _syncContext;
        private Action<T> _action;
        private int _delay;
        private Thread _thread;
        public DelayedAction(Action<T> action)
            : this(action, 0)
        {
        }
        public DelayedAction(Action<T> action, int delay)
        {
            _action = action;
            _delay = delay;
            _syncContext = SynchronizationContext.Current;
        }
        public void RunAfterDelay()
        {
            RunAfterDelay(_delay, default(T));
        }
        public void RunAfterDelay(T param)
        {
            RunAfterDelay(_delay, param);
        }
        public void RunAfterDelay(int delay)
        {
            RunAfterDelay(delay, default(T));
        }
        public void RunAfterDelay(int delay, T param)
        {
            Cancel();
            InitThread(delay, param);
            _thread.Start();
        }
        public void Cancel()
        {
            if (_thread != null && _thread.IsAlive)
            {
                _thread.Abort();
            }
            _thread = null;
        }
        private void InitThread(int delay, T param)
        {
            ThreadStart ts =
                () =>
                {
                    Thread.Sleep(delay);
                    _syncContext.Send(
                        (state) =>
                        {
                            _action((T)state);
                        },
                        param);
                };
            _thread = new Thread(ts);
        }
    }
