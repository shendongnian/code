    string quote = "Underground; round; unstable; unique; queue";
	Regex negativeViewBackward = new Regex(@"\b(?!un)\w+\b", RegexOptions.IgnoreCase);
	List<string> result = negativeViewBackward.Matches(quote).Cast<Match>().Select(x => x.Value).ToList();
	foreach (string s in result)
    	Console.WriteLine(s);
