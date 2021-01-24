    List<string> f = new List<string> ( ) { "A", "B", "C", "D", "E", "F", "G" };
        string text = "&2&LL&1&likk&3&";
        for ( int i = 0; i < f.Count; i++ )
        {
            text = text.RegexReplace ( text, "&" + i + "&", f[ i ] );
        }
        Console.WriteLine ( text );
