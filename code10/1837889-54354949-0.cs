    public static class ListExtensions
    {
    	public static void SetUnderlyingArray<T>(this List<T> list, T[] array)
    	{
    		lock (list)
    		{
    			SetInternalArray(list, array);
    			SetInternalArraySize(list, array.Length);
    		}
    	}
    
    	private static void SetInternalArraySize<T>(this List<T> list, int size)
    	{
    		var prop = list.GetType().GetField(
    			"_size", 
    			BindingFlags.NonPublic | BindingFlags.Instance);
    		prop.SetValue(list, size);
    	}
    
    	private static void SetInternalArray<T>(this List<T> list, T[] array)
    	{
    		var prop = list.GetType().GetField(
    			"_items",
    			BindingFlags.NonPublic | BindingFlags.Instance);
    		prop.SetValue(list, array);
    	}
    }
