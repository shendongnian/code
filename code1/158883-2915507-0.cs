    DateTime? time;
    
    buttonClick(....)
    {
    	if (time.HasValue)
    	{
    		TimeSpan diff = DateTime.Now.Subtract(time.Value);
                DoSomethingWithDiff(diff);
    		time = null;
    	}
    	else
    	{
    		time = DateTime.Now;
    	}
    }
