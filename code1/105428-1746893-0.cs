    public string Code
    {
    	set 
    	{
    		if (value.Length != 7)
    			throw new Exception("Length must be 7.");
    		_code = value;
    	}
    }
