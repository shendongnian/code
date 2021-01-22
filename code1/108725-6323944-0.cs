    static void F(int[] array, int n)
    {
    	Console.WriteLine(array[n] = n);
    	F(array, n + 1);
    }
    static void Main(string[] args)
    {
    	try { F(new int[101], 1); }
    	catch (Exception e) { }
    }
