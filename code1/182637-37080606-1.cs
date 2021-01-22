        private bool _btnEnabled;
        public bool btnEnabled
        {
            get { return _btnEnabled; }
            set
            {
                if (_btnEnabled != value)
                {
                    _btnEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
