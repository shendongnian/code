    Console.WriteLine("{0:D10}", 2); // 0000000002
    
    Dictionary<string, string> dict = new Dictionary<string, string> { 
    	{"David", "C#"}, 
    	{"Johann", "Perl"}, 
    	{"Morgan", "Python"}
    };
    
    Console.WriteLine( "{0,10} {1, 10}", "Programmer", "Language" );
    
    Console.WriteLine( "-".PadRight( 21, '-' ) );
    
    foreach (string key in dict.Keys)
    {
    	Console.WriteLine( "{0, 10} {1, 10}", key, dict[key] );				
    }
