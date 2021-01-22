    protected void Sort()
    {
    	foreach (string key in _dBase.Keys)
    	{
    	  Array.Sort<Pair<string, Dictionary<string, T>>>(_dBase[key], 
                new Comparison<Pair<string, Dictionary<string, T>>>(
    		delegate(Pair<string, Dictionary<string, T>> a, Pair<string, Dictionary<string, T>> b)
    		{
    			if (a == null && b != null)
    				return 1;
    			else if (a != null && b == null)
    				return -1;
    			else if (a == null && b == null)
    				return 0;
    			else
    				return a.First.CompareTo(b.First);
    		}));
    	}
    }
