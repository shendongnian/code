    static void Main() 
    {
        string input = @"Dear $name$, as of $date$ your balance is $amount$";
    	var args = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    	args.Add("name", "Mr Smith");
    	args.Add("date", "05 Aug 2009");
    	args.Add("amount", "GBP200");
    	Regex re = new Regex(@"\$(\w+)\$", RegexOptions.Compiled);
    	string output = re.replaceTokens(input, args);
    	// spot the LinqPad user // output.Dump();
    }
    public static class ReplaceTokensUsingDictionary
    {
    	public static string replaceTokens(this Regex re, string input, IDictionary<string, string> args)
    	{
    		return re.Replace(input, match => args[match.Groups[1].Value]);
    	}
    }
