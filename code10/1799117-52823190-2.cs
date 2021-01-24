	public static void Main()
	{
		_Combinations.Add(new Combination{ CombinationSet = new List<int>{ 1, 2, 3}});
		_Combinations.Add(new Combination{ CombinationSet = new List<int>{ 2, 3, 4}});
		_Combinations.Add(new Combination{ CombinationSet = new List<int>{ 3, 2, 1}});
		_Combinations.Add(new Combination{ CombinationSet = new List<int>{ 1, 2, 3}});
		
		Console.WriteLine("Test 1  (1,2,3)");
		foreach(var result in FindCombinations(1,2,3))
		{
			Console.WriteLine(result.ToString());
		}
		
		Console.WriteLine("Test 1  (3,2,1)");
		foreach(var result in FindCombinations(3,2,1))
		{
			Console.WriteLine(result.ToString());
		}
		
		Console.WriteLine("Test 1  (1,2)");
		foreach(var result in FindCombinations(1,2))
		{
			Console.WriteLine(result.ToString());
		}
	}
