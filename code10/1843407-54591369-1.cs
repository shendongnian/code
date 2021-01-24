    public class ApprovedComparer : IComparer<bool?>
    {
    	public int Compare(bool? x, bool? y)
    	{
    		var a = 0;
    		var b = 0;
    
    		if (x.HasValue)
    			a = x.Value ? 1 : 2;
    		if (y.HasValue)
    			b = y.Value ? 1 : 2;
    
    		return a - b;
    	}
    }
