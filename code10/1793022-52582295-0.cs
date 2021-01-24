    static void Main(string[] args)
    {
	int compValue = 5;
	int[] values0 = { 1, 2, 5, 7, 8 };
	void ContainsValue(int[] array, int valueToTest)
	{
		bool isContained = array.Contains(valueToTest);
		if (isContained)
			Console.WriteLine($"{valueToTest} is in array");
		else
			Console.WriteLine($"{valueToTest} is not in array");
	}
	void CompareArrays(int[] array, int[] arrayToTest)
	{
		var comparer = StructuralComparisons.StructuralEqualityComparer ;
		var areEqual = comparer.Equals(array, arrayToTest);
		Console.WriteLine("-------------");
		if (areEqual)
		{
			Console.WriteLine("Arrays are equal");
		}
		else
		{
			Console.WriteLine("Arrays are not equal");
		}
	}
	ContainsValue(values0, compValue);
	int[] compArray1 = { 1, 2, 5, 7, 8 };
	CompareArrays(values0, compArray1);
	int[] compArray2 = { 1, 2, 5, 15, 8 };
	CompareArrays(values0, compArray2);
	CompareArrays(compArray2, values0);
    }
