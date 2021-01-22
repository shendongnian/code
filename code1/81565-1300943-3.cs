    public CompanyTypes Type 
            {
                get
                {
                    return _type;
                }
                set
                {
                    _type = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Type"));
    
                }
            }
