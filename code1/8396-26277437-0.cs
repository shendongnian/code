    public static void Init<T>(this T[] arr, Func<int, T> factory)
    {
    	for (int i = 0; i < arr.Length; i++)
    	{
    		arr[i] = factory(i);
    	}
    }
