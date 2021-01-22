    class MyHappyList<T> : List<T>
    {
    	public new void Add(T item)
    	{
    		if (Count > 9)
    		{
    			Remove(this[0]);
    		}
    
    		base.Add(item);
    	}
    }
