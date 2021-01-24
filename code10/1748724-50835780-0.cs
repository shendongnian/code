    public string doSomething(Ibar item)
    {
    	switch (item)
    	{
    		case bar b:
    			return b.a;
    		case bar2 b:
    			return b.b.ToString();
    		case barX b:
    			return b.X.ToString();
    		default:
    			return item.GetType().ToString(); // Just in case...
    	}
    }
