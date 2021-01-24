	private static string RemoveNumber(string text)
    {
		var result = string.Join("-", text.Split('-').Skip(1));
        return result;
    }
//Also Updated .Net fiddle
