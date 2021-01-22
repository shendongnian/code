    static class Extensions
    {
    	public static void DoStuffAndDisposeElements<T> ( this List<T> list, Action<T> action )
    	{
    		list.ForEach ( x => action(x));
    		foreach ( T o in list )
    		{
    			if (o is IDisposable)
    				(o as IDisposable).Dispose ();
    		}
    	}
    
    }
