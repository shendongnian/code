    var regex = new Regex(@"Converting table (\w+)\b\W+Table.+?converted");
    var matches = regex.Matches(input);
    foreach(Match match in matches) 
    {
    	Console.WriteLine(match.Groups[0].Value); // The whole string that matches.
    	Console.WriteLine("Table: " + match.Groups[1].Value); // Table name
    }
