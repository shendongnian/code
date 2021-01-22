    void Main()
    {
    	int[] array = { 1, 2, 3, 4, 5};
    	array.JustDo(x => Console.WriteLine(x));
    }
    
    public static class MyExtension
    {
    	public static void JustDo<T>(this IEnumerable<T> ext, Action<T> a)
    	{
    		foreach(T item in ext)
    		{
    			a(item);
    		}
    	}
    }
