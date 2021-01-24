	public static string TextDecipher1(string d) =>
		Regex.Replace(d, $"[{Regex.Escape("@#^*+")}]", "");
	
	public static string TextDecipher2(string d) =>
		"@#^*+".Aggregate(d, (a, x) => a.Replace(x.ToString(), ""));
	
	public static string TextDecipher3(string d) =>
		String.Join("", "@#^*+".Aggregate(d.ToList(), (a, x) => {a.RemoveAll(c => c == x); return a; }));
	Console.WriteLine(TextDecipher1("#$#@@ss"));
	Console.WriteLine(TextDecipher2("#$#@@ss"));
	Console.WriteLine(TextDecipher3("#$#@@ss"));
