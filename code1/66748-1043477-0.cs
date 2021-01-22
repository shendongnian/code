	public static void RunSnippet()
	{
		string s = File.ReadAllText (@"D:\txt.txt");
		Console.WriteLine (s);
		int i = s.IndexOf("se\\\">");
		Console.WriteLine (i);
	}
