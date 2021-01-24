    public class ListComparer : IEqualityComparer<List<object>>
    {
    	public bool Equals(List<object> a, List<object> b)
    	{
    		if (a.Count != b.Count)
    			return false;
    		for (int i = 0; i < a.Count; i++)
    			if (a[i] != b[i]) 
    				return false;
    		return true;
    	}
    
    	public int GetHashCode(List<object> list)
    	{
    		var hash = 0;
    		foreach (var item in list)
    		{
    			hash = hash ^ item.GetHashCode();
    		}
    		return hash;
    	}
    }
