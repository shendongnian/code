        private string _d;
   
        public string D
        {
            get => _d;
            set
            {
                _d = value;
                OnPropertyChanged(nameof(D));
            }
        }
