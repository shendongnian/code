	int days = 5;
	Console.WriteLine("Please enter 5 days of the week.");
	string[] first = Enumerable.Range(0, days).Select(x => Console.ReadLine()).ToArray();
	
	Console.WriteLine("Please enter the corresponding rain data.");
	string[] second = Enumerable.Range(0, days).Select(x => Console.ReadLine()).ToArray();
	
	string[][] rainfallData = new[] { first, second };
	
	Console.WriteLine("Data placed in raindallData[][] jaggard array.");
	Console.WriteLine(String.Join("", Enumerable.Range(0, days).Select(x => $"rainfallData[0][{1}]={rainfallData[0][x]}\n")));
	Console.WriteLine(String.Join(Environment.NewLine, Enumerable.Range(0, days).Select(x => $"rainfallData[1][{1}]={rainfallData[1][x]}")));
	
	double rainsum = rainfallData.Sum(i => i.Sum(j => double.Parse(j)));
	Console.WriteLine($"Data values calculated using iteration. \n a) Sum of rainfallData[][] = {rainsum}");
