    public void PrintValues(int? a = null, int? b = null, float? c = null, string s = "")
	{
		if(a.HasValue)
			Console.Write(a);
		else
			Console.Write("-");
		if(b.HasValue)
			Console.Write(b);
		else
			Console.Write("-");
		if(c.HasValue)
			Console.Write(c);
		else
			Console.Write("-");
    
        if(s != "") // Different check for strings
			Console.Write(s);
		else
			Console.Write("-");
	}
    
