    class foo: ObservableObject
    {
    private int _x;
    public int x
    {
    	get
    	{
    		return _x;
    	}
    	set
    	{
    		_x = value;
    		OnPropertyChanged("x");
    	}
    }
    class bar : ObservableObject
    {
    	private foo _y;
    	public foo y
    	{
    		get
    		{
    			return _y;
    		}
    		set
    		{
    			if (_y!=null)
    			{
    				_y.PropertyChanged -= _y_PropertyChanged;
    			}
    
    			_y = value;
    			_y.PropertyChanged += _y_PropertyChanged;
    
    			OnPropertyChanged("y");
    			OnPropertyChanged("pow");
    		}
    	}
    
    	private void _y_PropertyChanged(object sender, PropertyChangedEventArgs e)
    	{
    		//if(e.PropertyName == "x");
    		OnPropertyChanged("pow");
    	}
    
    	public int pow { get { return _y.x * 2;} }
    }
