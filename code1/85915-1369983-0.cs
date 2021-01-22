    public class Timer : IDisposable
    {
        internal Stopwatch _stopwatch;
        public Timer()
        {
            this._stopwatch = new Stopwatch();
            this._stopwatch.Start();
        }
    
        public void Dispose()
        {
            this._stopwatch.Stop();
        }
    }
