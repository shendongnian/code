        private double _powerValue = 0;
        public double? Power { get; set; } = 0;
        public bool IsPowerEnabled
        {
            get => _isPowerEnabled;
            set
            {
                _isPowerEnabled = value;
                if (!value)
                {
                    _powerValue = Power.Value;
                    Power = null;
                }
                else
                {
                    Power = _powerValue;
                }
                NotifyOfPropertyChange(nameof(Power));
                NotifyOfPropertyChange(nameof(IsPowerEnabled));
            }
        }
