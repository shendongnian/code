	string temps = "1.1 °C 40.5 °C 42.4 °C 39.9 °C 40.0 °C 4.0 °C 11.1 °C";
	decimal sum = 0m;
	int count = 0;
	for (int i = 0; i < temps.Length; i += temps[i + 4] == ' ' ? 8 : 7)
	{
		string t = temps.Substring(i, 4).TrimEnd();
		Console.WriteLine(t);
		sum += Decimal.Parse(t);
		count++;
	}
	decimal avg = sum / count;
	Console.WriteLine("Avg = " + avg.ToString());
