    private bool _Selected;
            public bool Selected
            {
                get
                {
                    return _Selected;
                }
                set
                {
                    if (PropertyChanged != null)                
                        PropertyChanged(this, new PropertyChangedEventArgs("Selected"));
                    
                    _Selected = value;
                }
            }
    
