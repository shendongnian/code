            private Person _selected;
            public Person MySelected
            {
                get { return _selected; }
                set
                {
                    if (value != _selected)
                    {
                        _selected = value;            
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this,
                                new PropertyChangedEventArgs("MySelected"));
                        }
                    }
                }
            }
