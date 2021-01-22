    string _name
    public string name
    {
    	get { return _name; }
    	set
    	{
    		if(value.Equals(_name)) return;
    		_name = value;
    		OnPropertyChanged("name");
    	}
    }
