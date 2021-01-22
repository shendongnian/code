	int[] testInts = { 0, 1, -1, int.MaxValue, int.MinValue };
	uint[] testUints = { uint.MinValue, 1, uint.MaxValue / 2, uint.MaxValue };
	foreach (var Int in testInts)
	{
		uint asUint = unchecked((uint)Int);
		Console.WriteLine("int....: {0:D10} ({1})", Int, BitConverter.ToString(BitConverter.GetBytes(Int)));
		Console.WriteLine("asUint.: {0:D10} ({1})", asUint, BitConverter.ToString(BitConverter.GetBytes(asUint)));
		Console.WriteLine(new string('-',30));
	}
	Console.WriteLine(new string('=', 30));
	foreach (var Uint in testUints)
	{
		int asInt = unchecked((int)Uint);
		Console.WriteLine("uint...: {0:D10} ({1})", Uint, BitConverter.ToString(BitConverter.GetBytes(Uint)));
		Console.WriteLine("asInt..: {0:D10} ({1})", asInt, BitConverter.ToString(BitConverter.GetBytes(asInt)));
		Console.WriteLine(new string('-', 30));
	}  
