	var bytes = IPAddress.Parse("127.0.0.1").GetAddressBytes();
		
	if (!BitConverter.IsLittleEndian)
	   Array.Reverse(bytes);
		
	for (int i = 0; i < bytes.Length; i++)
		Console.Write(bytes[i].ToString("X2"));
		
	Console.WriteLine("");
		
	long r = BitConverter.ToInt32(bytes, 0);
	Console.WriteLine(r);
