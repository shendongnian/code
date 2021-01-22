    public class ControlColorAnimator
    {
        private const int INTERVAL = 100;
        private readonly decimal _alphaIncrement;
        private readonly decimal _blueIncrement;
        private readonly Color _endColor;
        private readonly decimal _greenIncrement;
        private readonly int _iterations;
        private readonly decimal _redIncrement;
        private readonly Color _startColor;
        private decimal _currentAlpha;
        private decimal _currentBlueValue;
        private decimal _currentGreenValue;
        private decimal _currentRedValue;
        private Timer _timer;
        public ControlColorAnimator(TimeSpan duration, Color startColor, Color endColor)
        {
            _startColor = startColor;
            _endColor = endColor;
            resetColor();
            _iterations = duration.Milliseconds / INTERVAL;
            _alphaIncrement = ((decimal) startColor.A - endColor.A) / _iterations;
            _redIncrement = ((decimal) startColor.R - endColor.R) / _iterations;
            _greenIncrement = ((decimal) startColor.G - endColor.G) / _iterations;
            _blueIncrement = ((decimal) startColor.B - endColor.B) / _iterations;
        }
        public Color CurrentColor
        {
            get
            {
                int alpha = Convert.ToInt32(_currentAlpha);
                int red = Convert.ToInt32(_currentRedValue);
                int green = Convert.ToInt32(_currentGreenValue);
                int blue = Convert.ToInt32(_currentBlueValue);
                return Color.FromArgb(alpha, red, green, blue);
            }
        }
        public event EventHandler<DataEventArgs<Color>> ColorChanged;
        public void Go()
        {
            disposeOfTheTimer();
            OnColorChanged(_startColor);
            resetColor();
            int currentIteration = 0;
            _timer = new Timer(delegate
                {
                    if (currentIteration++ >= _iterations)
                    {
                        Stop();
                        return;
                    }
                    _currentAlpha -= _alphaIncrement;
                    _currentRedValue -= _redIncrement;
                    _currentGreenValue -= _greenIncrement;
                    _currentBlueValue -= _blueIncrement;
                    OnColorChanged(CurrentColor);
                }, null, TimeSpan.FromMilliseconds(INTERVAL), TimeSpan.FromMilliseconds(INTERVAL));
        }
        public void Stop()
        {
            disposeOfTheTimer();
            OnColorChanged(_endColor);
        }
        protected virtual void OnColorChanged(Color color)
        {
            if (ColorChanged == null) return;
            ColorChanged(this, color);
        }
        private void disposeOfTheTimer()
        {
            Timer timer = _timer;
            _timer = null;
            if (timer != null) timer.Dispose();
        }
        private void resetColor()
        {
            _currentAlpha = _startColor.A;
            _currentRedValue = _startColor.R;
            _currentGreenValue = _startColor.G;
            _currentBlueValue = _startColor.B;
        }
    }
