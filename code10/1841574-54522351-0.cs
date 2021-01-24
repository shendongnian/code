    internal static void Table(double original = 1000.0, double interest= 0.01, int years = 5)
	{
		for (int i = 1; i <= years; i++)
		{
			original = original * (1 + interest * i); // here, we consider the current amount as the new original
			Console.WriteLine("Year " + i + " value: " + original.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
		}
	}
