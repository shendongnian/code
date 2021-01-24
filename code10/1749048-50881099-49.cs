	public static void Main()
    {
        var tokens = new List<string>() { "1" , "+" , "2" , "+" , "3" , "+" , "4"};
        var parser = new Parser(tokens);
	    var result = parser.Parse();
		System.Console.WriteLine(result);
    }
