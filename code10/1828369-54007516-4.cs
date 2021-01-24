    foreach(var item in resultobject.QuoteLines)
    {
    	switch(item)
    	{
    		case A itemA :
    			Console.WriteLine($"Type A: {itemA.Order}, {itemA.PropertyA}");
    			break;
    		case B itemB :
    			Console.WriteLine($"Type A: {itemB.Order}, {itemB.PropertyB}");
    			break;
    		default:
    			Console.WriteLine("Error");
    			break;
    	}
    }
