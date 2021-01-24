	//Ask the user to enter five days of the week and rainfall data for each day
	Console.WriteLine("Please enter 5 days of the week.");
	//Store the data in a two dimensional string array named rainfallData[]
	for (int j = 0; j < days; j++)
	{
		rainfallData[0, j] = Console.ReadLine();
	}
	Console.WriteLine("Please enter the corresponding rain data.");
	for (int j = 0; j < days; j++)
	{
		rainfallData[1, j] = Console.ReadLine();
	}
	Console.WriteLine("Data placed in raindallData[] array.");
	for (int i = 0; i < columns; i++)
	{
		Console.WriteLine();
		for (int j = 0; j < days; j++)
		{
			Console.WriteLine("rainfallData({0},{1})={2}", i, j, rainfallData[i, j]);
		}
	}
	//Use iteration to calculate the following from the values in rainfallData[]:
	//a) sum
	double rainsum = 0.0;
	Console.Write("Data values calculated using iteration. \n a) Sum of rainfallData[] = ");
	for (int i = 0; i < columns; i++)
	{
		Console.WriteLine();
		for (int j = 0; j < days; j++)
		{
			rainsum += double.Parse(rainfallData[i, j]);
		}
	}
	Console.WriteLine(rainsum);
