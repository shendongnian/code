    private DateTime? _dt;
    public DateTime? Date
    {
    	get
    	{
    		if (!this._dt.HasValue)
    			return null;
    
    		return this._dt.Value == DateTime.MinValue ? null : this._dt;
    	}
    	set
    	{
    		this._dt = value;
    	}
    }
    
    public string DateAsString
    {
    	get
    	{
    		if (!this._dt.HasValue)
    			return string.Empty;
    
    		return this._dt.Value == DateTime.MinValue ? string.Empty : this._dt.Value.ToString();
    	}
    }
