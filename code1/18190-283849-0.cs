    List<string> lines = new List<string>
    	{
    		"34949 Toyota Yaris",
    		"328   Honda Civic",
    		"28437 Ford Fiesta"
    	};
    			
    var sortedLines = lines.OrderBy(line => line.Substring(6, 10));
    // Or make it case insensitive
    // var sortedLines = lines.OrderBy(line => line.Substring(6, 10), StringComparer.InvariantCultureIgnoreCase);
    		
    foreach (var line in sortedLines)
    {
    	Console.WriteLine(line);
    }
