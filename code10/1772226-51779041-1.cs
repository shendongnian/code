    string input = "print NUM";
    
    string[] tokens = new[] { "NUM", "EXPR", "STRING" };
    var myList = new List<string>(tokens);
    
    var searchTerm =string.IsNullOrEmpty(input) ? "" : input.Substring("print".Length, input.Length - "print".Length).Trim();
    
    var pos = myList.IndexOf(searchTerm);
    switch (pos)
    {
    // its NUM
    case 0:
    ...
    // its EXPR
    case 1: 
    ...
    // its STRING
    case 2:
    
    // not found or default
    case -1:
    }
