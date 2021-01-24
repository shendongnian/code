	string entry = "E#2";
	char[] output = new char[entry.Length];
	int j = 0;
	for(int i = 0; i < entry.Length ; i++)
	{
		if(!Char.IsDigit(entry[i]))
		{
			output[j] = entry[i];
			j++;
		}
	}
	Console.WriteLine(output);
