    using System.Text.RegularExpressions;
    	
    string data = "asdf aA asdfget aa uoiu AA";
    string aaRegex = "(.+?)[aA]{2}";
    
    MatchCollection mc = Regex.Matches(data, aaRegex);
    
    foreach(Match m in mc)
    {
    	Console.WriteLine(m.Value);
    }
