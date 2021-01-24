    string str = "asdf 12345";
    if (str.Length > 4)
    {
    	// Abbreviated ..
    	Console.WriteLine( "{0}", Regex.Match(str, @"(?s).{5}$").Value );
    
    	// Verbose ...
    	Regex rx = new Regex(@"(?s).{5}$");
    	str = rx.Match(str).Value;
    	Console.WriteLine( "{0}", str );
    }
    else {} // Do something else
