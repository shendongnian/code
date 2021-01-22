    public static IEnumerable<string> GetSplit( this string s, char c )
    {
        int l = s.Length;
        int i = 0, j = s.IndexOf( c, 0, l );
        if ( j == -1 ) // No such substring
        {
            yield return s; // Return original and break
            yield break;
        }
        while ( j != -1 )
        {
            if ( j - i > 0 ) // Non empty? 
            {
                yield return s.Substring( i, j - i ); // Return non-empty match
            }
            i = j + 1;
            j = s.IndexOf( c, i, l - i );
        }
        if ( i < l ) // Has remainder?
        {
            yield return s.Substring( i, l - i ); // Return remaining trail
        }
    }
