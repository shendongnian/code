	static void Main(string[] args)
	{
		int[] array = { 1, 2, 3, 4, 5 };
		IEnumerable<int> reverse = ReverseArray(array);
	
		foreach (int item in reverse)
		{
			Console.WriteLine(item);
		}
	}
	
	public static IEnumerable<int> ReverseArray(int[] arr)
	{
		for (int i = arr.Length - 1; i >= 0; i--)
		{
			yield return arr[i];
		}
	}
