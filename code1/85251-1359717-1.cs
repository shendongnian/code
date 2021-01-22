    string[] input = { "4:19 PM         5:15 PM  this is some text blah blah",
    		           "3:00 PM         5:00 PM  text"
    				 };
    // build up pattern
    string datePattern = @"(\d+:\d+\s(?:AM|PM))";
    string pattern = String.Format("^{0}{1}{2}{3}$",
                                   datePattern, @"\s+", datePattern, @"\s+.*");
    
    TimeSpan total = new TimeSpan();
    foreach (string text in input)
    {
    	var match = Regex.Match(text, pattern);
    	// skip first group which has entire match
    	DateTime dt1 = DateTime.Parse(match.Groups[1].Value);
    	DateTime dt2 = DateTime.Parse(match.Groups[2].Value);
    	TimeSpan diff = dt2 - dt1;
    	total += diff;
    }
    Console.WriteLine("Total difference: {0}", total);
