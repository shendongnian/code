    MatchCollection matches = Regex.Matches( text, @"([-]+\d{24})
                                                     (?<Content>.*?)
                                                     (?=\1)", 
                                             RegexOptions.IgnorePatternWhitespace | 
                                             RegexOptions.Singleline );
    
    foreach ( Match match in matches )
    {
        Console.WriteLine( 
            string.Format( "match: {0}\n\n", 
                           match.Groups[ "Content" ].Value ) );
    }
