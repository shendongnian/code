    public int SecondProperty
    {
       get { return _secondProperty; }
       set { 
                _secondProperty= value; 
                OnPropertyChanged("SecondProperty");
                myProperty = value + 1; // or whatever is appropriate
           }
    }
