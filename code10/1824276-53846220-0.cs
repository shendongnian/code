    public static void Main()
	{
		long numberId = 0;
		var testString = "Testcase3";
		long multiplier = (long)Math.Pow(10,testString.Length);
		foreach (var character in testString.ToCharArray())
		{
			numberId +=  Convert.ToInt16(character)*multiplier;
			multiplier /=10;
		}
		Console.WriteLine(numberId);
	}
