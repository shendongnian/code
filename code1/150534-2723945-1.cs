    public DateTime SomethingDate
    {
        get
        {
        	return this.Something;
        }
        set
        {
        	this.Something = value.Date.Add(this.Something.TimeOfDay);
        }
    }
    public DateTime SomethingTime
    {
    	get
    	{
    		return this.Something;
    	}
    	set
    	{
    		this.Something = this.Something.Date.Add(value.TimeOfDay);
    	}
    }
