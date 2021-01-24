    bool IsMemoryAvailable(int amount)
    {
    	int size = (int)Math.Sqrt(amount) / 2;
    
    	try
    	{
    		using (Bitmap bmpTest = new Bitmap(size, size))
    		{
    		
    		}
    		
    		GC.Collect();
    		
    		return true;
    	}
    	catch(Exception x)
    	{
    		return false;
    	}
    }
