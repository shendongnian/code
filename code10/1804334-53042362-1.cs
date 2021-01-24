        private bool _buttonPressed;
        public bool ButtonPressed
        {
            get
            {
                return _buttonPressed;
            }
            set
            {
                if (_buttonPressed != value)
                {
                    _buttonPressed = value;
                    OnPropertyChanged(nameof(ButtonPressed));
                }
            }
        }
