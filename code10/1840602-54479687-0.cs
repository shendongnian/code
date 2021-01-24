	public static void Main()
	{
		System.IO.File.AppendAllText("test","œ", System.Text.Encoding.GetEncoding(1252));
		var content = System.IO.File.ReadAllText("test", System.Text.Encoding.GetEncoding(1252));
		Console.WriteLine(content);
	}
