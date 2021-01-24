	while (true)
	{
		Console.WriteLine("Please put a value as binary");
		string input = Console.ReadLine();
		var number = Convert.ToUInt16(input, 2);
		Console.WriteLine($"input:{input}, value: {number}, as binary: {Convert.ToString(number, 2)}");
	}
	/*
	Please put a value as binary
	1
	input:1, value: 1, as binary: 1
	Please put a value as binary
	11
	input:11, value: 3, as binary: 11
	Please put a value as binary
	10000001
	input:10000001, value: 129, as binary: 10000001
	*/
