    public static class ArrayExtensionMethods
    {
    	public static ArraySegment<T> GetSegment<T>(this T[] arr, int offset, int? count = null)
    	{
    		if (count == null) { count = arr.Length - offset; }
    		return new ArraySegment<T>(arr, offset, count.Value);
    	}
    }
    
    void Main()
    {
    	byte[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
    	var p1 = arr.GetSegment(0, 5);
    	var p2 = arr.GetSegment(5);
    	Console.WriteLine("First array:");
    	foreach (byte b in p1)
    	{
    		Console.Write(b);
    	}
    	Console.Write("\n");
    	Console.WriteLine("Second array:");
    	foreach (byte b in p2)
    	{
    		Console.Write(b);
    	}
    }
