    public void Method<T>(T param)
    {
    	switch(param)
    	{
    		case var _ when param is A:
    		Console.WriteLine("A");
    		break;
    		case var _ when param is B:
    		Console.WriteLine("B");
    		break;
    		
    	}
    }
