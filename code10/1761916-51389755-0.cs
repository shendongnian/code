    public int Coke
    {
    	get { return _coke; }
    	set
    	{
    		if (_coke <= 0)
    		{
    			Console.WriteLine("No more Coke Left!");
    
    		}
    		else
    		{
    			_coke = value;
    		}
    	}
    }
