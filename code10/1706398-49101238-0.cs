    public class FilteredBool
    {
        private bool _inputValue;
        private bool _outputValue;
        private TimeSpan _minimumTime = TimeSpan.FromSeconds(5);
        private DateTime _lastChangeTime = DateTime.MinValue;
        public bool Value
        {
            get
            {
                if (_outputValue != _inputValue)
                {
                    if (_lastChangeTime + _minimumTime < DateTime.Now)
                        _outputValue = _inputValue;
                }
                return _inputValue;
            }
            set
            {
                if (_inputValue != value)
                {
                    _inputValue = value;
                    _lastChangeTime = DateTime.Now;
                }
            }
        }
        public TimeSpan MinimumTime
        {
            get { return _minimumTime; }
            set { _minimumTime = value; }
        }
        public static implicit operator bool(FilteredBool value)
        {
            return value.Value;
        }
    }
