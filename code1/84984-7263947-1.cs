    bool _isFocused = false;
        public bool IsFocused 
        {
            get { return _isFocused ; }
            set
            {
                _isFocused = false;
                _isFocused = value;
                base.OnPropertyChanged("IsFocused ");
            }
        }
