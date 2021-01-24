    static void TestRegex(char[] check_chars)
    {
    	string[] inputs = { "54323.5", "543g23.5" };
    	var check_chars2 = check_chars.Select(c => Regex.Escape(c.ToString()));
    	string pattern = "^(" + string.Join("|", check_chars2) + ")+$";
    	foreach (string input in inputs)
    	{
    		WriteLine($"Input {input} does{(Regex.IsMatch(input, pattern) ? "" : " not")} match");
    	}
    }
    // Output:
    // Input 54323.5 does match
    // Input 543g23.5 does not match
