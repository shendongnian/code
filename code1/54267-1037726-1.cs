    // holds backup of values
    private string __Sex;
    private string _Sex;
    public string Sex
    {
    	get
    	{
    		return _Sex;
    	}
    	set
    	{
    		bool changed = _Sex != value;
    		  if (changed)
    			{
    				this.RaisePropertyChanged("Sex");
    			}
    
    	}
    }
    
    
    #region IEditableObject Members
    
    private bool _editing = false;
    
    public void BeginEdit()
    {
    	if (!_editing)
    	{
    		// create copy of property
    		__Sex = _Sex;
    		//other properties here
    		_editing = true;
    	}
    }
    
    public void CancelEdit()
    {
    	if (_editing)
    	{
    		// revert back
    		_Sex = __Sex;
    		//other properties here
    		_editing = false;
    		
    	}
    }
    
    public void EndEdit()
    {
    	if (_editing)
    	{
    		_editing = false;
    	}
    }
    
    #endregion
  
  
