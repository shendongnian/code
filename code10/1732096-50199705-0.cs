    public static void NewValue ()
	{
		double val = 0;
		Console.WriteLine("Please enter a value");
		val = Convert.ToDouble(Console.ReadLine());
		_values.Add(val);
	}
