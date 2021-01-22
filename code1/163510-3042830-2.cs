    namespace Utils
    {
        public class StopWatch
        {
            protected DateTime _resetTime;
    
            public StopWatch() { Reset(); }
            public void Reset() { _resetTime = DateTime.Now; }
            public double TotalSeconds { get { return (DateTime.Now - _resetTime).TotalSeconds; } }
            public TimeSpan Time { get { return DateTime.Now - _resetTime; } }
        };
    
        public class Timeouter : StopWatch
        {
            private bool _autoReset;
            private double _timeout_s;
    
            public Timeouter(double timeout_s, bool autoReset, bool timedOut = false)
            {
                _timeout_s = timeout_s;
                _autoReset = autoReset;
    
                if (timedOut)
                    _resetTime -= TimeSpan.FromSeconds(_timeout_s + 1);  // This is surely timed out, as requested
            }
    
            public bool IsTimedOut()
            {
                if (_timeout_s == double.PositiveInfinity)
                    return false;
    
                bool timedout = this.TotalSeconds >= _timeout_s;
    
                if (timedout && _autoReset)
                    Reset();
    
                return timedout;
            }
    
            public void Reset(double timeout_s) { _timeout_s = timeout_s; Reset(); }
            public double TimeLeft { get { return _timeout_s - TotalSeconds; } }
        }
    }
