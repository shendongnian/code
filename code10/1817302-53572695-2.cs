        private double _powerValue;
        public double? Power { get; set; } = 0;
        public bool IsPowerChecked
        {
            get => _isPowerChecked;
            set
            {
                _isPowerChecked = value;
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
            }
        }
