	Regex rx = new Regex("[aeiou]");
	string[] words =
	{
		"aesthetic", "benevolent", "abstract",
		"capricious", "complacent", "conciliatory",
		"devious", "diligent", "discernible","dogmatic",
		"eccentric","fallacious","indifferent","inquisitive",
		"meticulous","pertinent","plausible", "reticent"
	};
	foreach (string input in words)
	{
		Console.WriteLine("String {0} contains {1} vowels",
			input, rx.Matches(input).Count);
	}
    // if you really want to use LINQ
    var query = from s in words
                select new
    			{
    			    Text = s,
    			    Count = rx.Matches(s).Count
    			};
    foreach (var item in query)
    {
    	Console.WriteLine("String {0} contains {1} vowels", item.Text, item.Count);
    }
