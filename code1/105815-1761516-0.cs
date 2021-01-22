            private bool _IsSelected = true;
            public bool IsSelected            
            {
                get
                {
                    return _IsSelected;
                }
                set
                {
                    if (value != _IsSelected)
                    {
                        _IsSelected = value;
                        OnPropertyChanged("IsSelected");
                    }
                }
