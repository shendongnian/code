    class JPropertyDocumentOrderComparer : IComparer<JProperty>
    {
    	public int Compare(JProperty x, JProperty y)
    	{
    		var xa = GetAncestors(x);
    		var ya = GetAncestors(y);
    		for (int i = 0; i < xa.Count && i < ya.Count; i++)
    		{
    			if (!ReferenceEquals(xa[i], ya[i])) 
    			{
    				return IndexInParent(xa[i]) - IndexInParent(ya[i]);
    			}
    		}
    		return xa.Count - ya.Count;
    	}
    	
    	private List<JProperty> GetAncestors(JProperty prop)
    	{
    		return prop.AncestorsAndSelf().OfType<JProperty>().Reverse().ToList();
    	}
    	
    	private int IndexInParent(JProperty prop)
    	{
    		int i = 0;
    		var parent = (JObject)prop.Parent;
    		foreach (JProperty p in parent.Properties())
    		{
    			if (ReferenceEquals(p, prop)) return i; 
    			i++;
    		}
    		return -1;
    	}
    }
