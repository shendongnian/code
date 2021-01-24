        private bool _isPowerChecked;        
        
        public bool IsPowerChecked
        {
            get => _isPowerChecked;
            set
            {
                _isPowerChecked = value;
                Power = null;
                NotifyOfPropertyChange(nameof(Power));
            }
        }
