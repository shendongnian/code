	public static void Main()
	{
		Console.WriteLine(Encoding.Default.BodyName);
		// I live in Italy, we use the Windows-1252 as the default codepage 
		Console.WriteLine(CanBeEncoded(Encoding.Default, "Hello world àèéìòù")); 				Console.WriteLine(CanBeEncoded(Encoding.Default, "Русский"));
	}
