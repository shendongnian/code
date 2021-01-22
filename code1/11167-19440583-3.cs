    /// <summary>
    /// Internal timer for window.setTimeout() and window.setInterval().
    /// This is to ensure that async calls always run on the same thread.
    /// </summary>
    public class Timer : IDisposable {
        public void Tick()
        {
            if (Enabled && Environment.TickCount >= nextTick)
            {
                Callback.Invoke(this, null);
                nextTick = Environment.TickCount + Interval;
            }
        }
        private int nextTick = 0;
        public void Start()
        {
            this.Enabled = true;
            Interval = (interval > 0) ? interval : 1000;
        }
        public void Stop()
        {
            this.Enabled = false;
        }
        public event EventHandler Callback;
        public bool Enabled = false;
        private int interval;
        public int Interval
        {
            get { return interval; }
            set { interval = value; nextTick = Environment.TickCount + interval; }
        }
        public void Dispose()
        {
            this.Callback = null;
            this.Stop();
        }
    }
