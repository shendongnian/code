    string input = string.Empty;	
    var list = new List<Pupils>();
    var regex = new Regex(@"(?<name>[a-zA-Z\s]+)\s+(?<altitude>[0-9]+)",RegexOptions.Compiled);
    while((input = Console.ReadLine()) != "q")
    {
    	var matches = regex.Match(input.Trim());
    	 list.Add(new Pupils
    	{ 
    		Name = matches.Groups["name"].Value, 
    		Altitude = int.Parse(matches.Groups["altitude"].Value)
    	});
    }
