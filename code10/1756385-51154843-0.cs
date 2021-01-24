     public bool IsBusyInstalling
        {
            get
            {
                return _isBusyInstalling;
            }
            private set
            {
                _isBusyInstalling = value;
                RaisePropertyChanged("IsBusyInstalling");
            }
        }
