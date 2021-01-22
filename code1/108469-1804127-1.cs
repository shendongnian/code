    public static void Main()
    {
		List<ValueType> values = new List<ValueType> {3, DateTime.Now, 23.4M};
		DuplicateLastItem(values);
		
		Console.WriteLine(values[2]);
		Console.WriteLine(values[3]);
		values[3] = 20;
		Console.WriteLine(values[2]);
		Console.WriteLine(values[3]);
	}
	static void DuplicateLastItem(List<ValueType> values2)
	{
		values2.Add(values2[values2.Count - 1]);
	}
