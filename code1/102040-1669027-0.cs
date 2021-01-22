    public int MyProperty {
        get { return myProperty; }
        set
        {
            myProperty = value;
            RaisePropertyChanged( () => MyProperty );
        }
    }
    
