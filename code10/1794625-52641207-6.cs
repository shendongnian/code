    public class LerpTimer : IDisposable
    {
        private readonly Timer _timer;
        private readonly float _incrementPercentage = 0;
        public event EventHandler<float> DoLerp;
        public event EventHandler Complete;
        private bool _isDisposed = false;
        private float _current;
        public LerpTimer(double frequencyMs, float incrementPercentage)
        {
            if (frequencyMs <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(frequencyMs), "Frequency must be greater than 1ms.");
            }
            if (incrementPercentage < 0 || incrementPercentage > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(incrementPercentage), "Increment percentage must be a value between 0 and 1");
            }
            _timer = new Timer(frequencyMs);
            _timer.Elapsed += _timer_Elapsed;
            _incrementPercentage = incrementPercentage;
        }
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_isDisposed)
            {
                return;
            }
            if (this.Current < 100)
            {
                this.Current = Math.Min(100, this.Current + _incrementPercentage);
                this.DoLerp?.Invoke(this, this.Current);
            }
            if (this.Current >= 100)
            {
                this._timer.Stop();
                this.Complete?.Invoke(this, EventArgs.Empty);
            }
        }
        public float Current
        {
            get
            { 
                if (_isDisposed)
                {
                    throw new ObjectDisposedException(nameof(LerpTimer));
                }
                return _current;
            }
            set => _current = value;
        }
        public void Start()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(LerpTimer));
            }
            if (_timer.Enabled)
            {
                throw new InvalidOperationException("Timer already running.");
            }
            this.Current = 0;
            _timer.Start();
        }
        public void Stop()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(LerpTimer));
            }
            if (!_timer.Enabled)
            {
                throw new InvalidOperationException("Timer not running.");
            }
            _timer.Stop();
        }
        public void Dispose()
        {
            _isDisposed = true;
            _timer?.Dispose();
        }
    }
