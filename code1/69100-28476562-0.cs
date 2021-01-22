	using System;
	enum Importance
	{
		None,
		Low,
		Medium,
		Critical
	}
	class Program
	{
		static void Main()
		{
		// The input value.
		string value = "Medium";
		// An unitialized variable.
		Importance importance;
		// Call Enum.TryParse method.
		if (Enum.TryParse(value, out importance))
		{
			// We now have an enum type.
			Console.WriteLine(importance == Importance.Medium);
		}
		}
	}
