	var currentPrograms = ExtractCurrentPrograms(concentrationArray);
	if (currentPrograms.Any())
	{
		lstTest.Items.AddRange(currentPrograms);
	}
...
    private static IEnumerable<string> ExtractCurrentPrograms(IEnumerable<string> lines)
    {
    	const string targetPhrase = "Current Program(s):";
    
    	foreach (var line in lines.Where(l => !string.IsNullOrWhiteSpace(l)))
    	{
    		var index = line.IndexOf(targetPhrase);
    
    		if (index >= 0)
    		{
    			var programIndex = index + targetPhrase.Length;
    			var text = line.Substring(programIndex).Trim();
    
    			if (!string.IsNullOrWhiteSpace(text))
    			{
    				yield return text;
    			}
    		}
    	}
    }
