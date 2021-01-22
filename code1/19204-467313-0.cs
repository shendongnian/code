    public static string[] SplitCommandLineArgument( String argumentString )
    {
        StringBuilder translatedArguments = new StringBuilder( argumentString ).Replace( "\\\"", "\r" );
        bool InsideQuote = false;
        for ( int i = 0; i < translatedArguments.Length; i++ )
        {
            if ( translatedArguments[i] == '"' )
            {
                InsideQuote = !InsideQuote;
            }
            if ( translatedArguments[i] == ' ' && !InsideQuote )
            {
                translatedArguments[i] = '\n';
            }
        }
        string[] toReturn = translatedArguments.ToString().Split( new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries );
        for ( int i = 0; i < toReturn.Length; i++ )
        {
            toReturn[i] = RemoveMatchingQuotes( toReturn[i] );
            toReturn[i] = toReturn[i].Replace( "\r", "\"" );
        }
        return toReturn;
    }
    public static string RemoveMatchingQuotes( string stringToTrim )
    {
        int firstQuoteIndex = stringToTrim.IndexOf( '"' );
        int lastQuoteIndex = stringToTrim.LastIndexOf( '"' );
        while ( firstQuoteIndex != lastQuoteIndex )
        {
            stringToTrim = stringToTrim.Remove( firstQuoteIndex, 1 );
            stringToTrim = stringToTrim.Remove( lastQuoteIndex - 1, 1 ); //-1 because we've shifted the indicies left by one
            firstQuoteIndex = stringToTrim.IndexOf( '"' );
            lastQuoteIndex = stringToTrim.LastIndexOf( '"' );
        }
        return stringToTrim;
    }
