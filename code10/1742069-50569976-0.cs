	public static void Main()
	{
		var ints = new int[]{0,2,5,8};
		foreach (var i in Print(ints))
		{
			Console.WriteLine(i);
		}
	}
	
	public static int[] Print(int[] numbers)
	{
		Console.WriteLine("Hello");
		return numbers;
	}
