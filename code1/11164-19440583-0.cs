    /// <summary>
    /// Internal timer for window.setTimeout() and window.setInterval().
    /// This is to ensure that async calls always run on the same thread.
    /// </summary>
    public class Timer : IDisposable {
        public void Tick() {
            if (Enabled && Environment.TickCount >= nextTick) {
                Callback.Invoke(this, null);
                nextTick = Environment.TickCount + Interval;
            }
        }
        private int start;
        private int nextTick;
        public void Start() {
            start = Environment.TickCount;
            Interval = (interval == null) ? 1000 : interval;
        }
        public void Stop() {
            this.Enabled = false;
        }
        public event EventHandler Callback;
        public bool Enabled = true;
        private int interval;
        public int Interval {
            get { return interval; }
            set { interval = value; nextTick = Environment.TickCount + interval; }
        }
        public void Dispose()
        {
            this.Callback = null;
            this.Stop();
        }
    }
