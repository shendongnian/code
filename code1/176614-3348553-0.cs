    internal virtual bool? isActive {get;set;}
    public bool MyInterface.IsActive 
    {
    	get{ return isActive ?? false; }
    	set{ isActive == value ?? false; };
    }
