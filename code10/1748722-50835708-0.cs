    static void Main(string[] args)
    {
		var lines = System.IO.File.ReadLines(@"C:\Users\chri749y\Documents\Skrive til fil\Testprogram.txt");
		foreach (var batch in Batch(lines, 15))
		{
			foreach (var line in batch)
			{
				Console.WriteLine(line);
			}
			Console.ReadKey();
		}
		Console.ReadKey();
	}
