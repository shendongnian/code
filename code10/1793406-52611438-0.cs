    Regex rg = new Regex(@"time=""([^""]+)"" date=""([^""]+)""");
    
    Match m = rg.Match(s);
    
    if (m != null)
    {
    	string timeString = m.Groups[1].Captures[0].Value;
    	
    	string dateString = m.Groups[2].Captures[0].Value;
    	
        DateTime theDate = DateTime.Parse(dateString+" "+timeString.Substring(0,12)).Dump();
    }
