    private object _lock = new object();
    
    private void Reset()
    {
    	lock(_lock)
    	{
    		// your code here
    	}
    }
    
    void f_PriceChanged(Objet f, eventData e)
    {
    	lock(_lock)
    	{
    	    if (prices.ContainsKey(e.ItemText))
    	        prices[e.ItemText] = e.price;
    	    else
    	        prices.Add(e.ItemText, e.price);
    	}
    
    }
