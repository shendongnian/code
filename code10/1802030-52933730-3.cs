	static void Main(string[] args)
	{
		int[] array = { 1, 2, 3, 4, 5 };
		ReverseArray(array);
	
		foreach (int item in array)
		{
			Console.WriteLine(item);
		}
	}
	
	public static void ReverseArray(int[] arr)
	{
		int x = arr.Length - 1;
		for (int i = 0; i < x; i++, x--)
		{
			int temp = arr[x];
			arr[x] = arr[i];
			arr[i] = temp;
		}
	}
