	double[] readNumbers(int items, string title)
	{
		Console.WriteLine($"Please enter {items} of {title} data.");
		int attempt = 0;
		return
			Enumerable
				.Range(0, items)
				.Select(x =>
				{
					double result;
					while (!double.TryParse(Console.ReadLine(), out result))
					{
						Console.WriteLine($"Input not a number. Please try again.");
					}
					return result;
				})
				.ToArray();
	}
	
	int days = 5;
	double[] first = readNumbers(days, "first columnn");
	double[] second = readNumbers(days, "rain data");
	double[][] rainfallData = new[] { first, second };
	Console.WriteLine("Data placed in raindallData[][] jaggard array.");
	Console.WriteLine(String.Join("", Enumerable.Range(0, days).Select(x => $"rainfallData[0][{1}]={rainfallData[0][x]}\n")));
	Console.WriteLine(String.Join(Environment.NewLine, Enumerable.Range(0, days).Select(x => $"rainfallData[1][{1}]={rainfallData[1][x]}")));
	double rainsum = rainfallData.Sum(i => i.Sum());
	Console.WriteLine($"Data values calculated using iteration. \n a) Sum of rainfallData[][] = {rainsum}");
