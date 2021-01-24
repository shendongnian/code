    List<string> matches = new List<string>();
    for( int i = 0; i < str.Length; i++ )
    {
        foreach ( string toCompare in subStringsToCompare )
        {
            if ( str.SubString( i, toCompare.Length ) == toCompare )
                matches.Add( toCompare );
        }
    }
    string longest = "";
    foreach ( string match in matches )
    {
        if ( match.Length > longest.Length )
            longest = match;
    }
