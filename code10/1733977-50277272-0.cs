    private static string pattern = @"^GET_LIST(?:\s+([A-Za-z0-9]{4,10})){0,100}$";
    private static List<string> ExtractListId(string command)
    {
        return Regex.Matches(command, pattern)
    		.Cast<Match>().SelectMany(p => p.Groups[1].Captures
    			.Cast<Capture>()
    			.Select(t => t.Value)
    		)
    		.ToList();
    }
