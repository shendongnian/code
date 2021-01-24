    public static class MyClassEx
    {
    	public static IEnumerable<MyClass> FindSourcePath(
            this MyClass startItem, 
            IList<MyClass> items)
    	{ 
    		return startItem.FindSourcePath(items.ToDictionary(x => x.Id));
    	}
    	public static IEnumerable<MyClass> FindSourcePath(
            this MyClass startItem, 
            IDictionary<int, MyClass> itemDic)
    	{
    		var curr = startItem;
    		var visited = new HashSet<int>();
    		while (visited.Add(curr.Id))
    		{
    			yield return curr;
    			if (curr.ParentId == 0)
    			{
    				yield break;
    			}
    			if (!itemDic.TryGetValue(curr.ParentId, out curr))
    			{
    				throw new Exception("invalid parent ref");
    			}
    		}
    		throw new Exception("loop detected");
    	}
    }
