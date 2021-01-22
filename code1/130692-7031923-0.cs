    private string _myProperty;
    public string MyProperty
    {
	    get { return _myProperty; }
	    set
	    {
		    if (_myProperty != value)
		    {
		    	_myProperty = value;
		    	OnPropertyChanged("MyProperty");
		    }
	    }
    }
