    public bool ExistInDatabase
            {
                get { return _exitsInDatabase; }
                set
                {
                    _exitsInDatabase = value;
                    OnPropertyChanged();
                }
            }
