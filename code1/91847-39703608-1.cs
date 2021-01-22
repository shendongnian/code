            get
            {
                return _Password;
            }
            set
            {
                _Password = value; NotifyPropertyChanged();
                PasswordChar = _Password;
            }
        }
