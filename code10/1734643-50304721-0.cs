	var input = "3e43";
	var val = double.Parse(input, NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint);
	Console.WriteLine(val);
	Console.WriteLine(val.ToString("N0"));
	Console.WriteLine(val.ToString("f"));
