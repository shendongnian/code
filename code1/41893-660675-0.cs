    class Base
    {
    	protected Boolean Flag { get; set; }
    
    	public void Foo()
    	{
    		if (this.Flag)
    		{
    			// logic here
    		}
    	}
    }
    
    class Child : Base
    {
    	public Child()
    	{
            // you can set Flag anywhere you wish
    		this.Flag = true;
    	}
    }
