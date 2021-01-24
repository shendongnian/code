	var elements = new List<string>(new[] { "A", "B", "C" });
	
	Console.WriteLine("C#'s &&");
	
	elements.Where(x => {
		if (x == "A")
		{
			Console.WriteLine("ConditionA is true");
			if (1 == 1)
			{
				Console.WriteLine("ConditionB is true");
				return true;
			}
			
			Console.WriteLine("ConditionB is false");
		}
		
		Console.WriteLine("ConditionA is false");
		
		return false;			
	}).ToList();
	
	Console.WriteLine();
	Console.WriteLine("Double Linq.Where");
	
	elements.Where(x => {
		if (x == "A")
		{
			Console.WriteLine("ConditionA is true");
			return true;
		}
		
		Console.WriteLine("ConditionA is false");
		return false;			
	})
		.Where(x => {
			if (1 == 1)
			{
				Console.WriteLine("ConditionB is true");
				return true;
			}
			
			Console.WriteLine("ConditionB is false");
			return false;
		}).ToList();
