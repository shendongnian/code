    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
	public static void Main()
	{
        var a = 5;
        var b = 6;
        Swap(ref a, ref b);
        Console.WriteLine("a={0},b={1}", a, b);
        Console.ReadKey();
  	}
