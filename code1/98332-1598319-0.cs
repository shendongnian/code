    static class MyEnumerators 
    {
        IEnumerable <string> NumberedStringEnumerator (string format, int start, int count)
        {
            for ( int n = 0; n < count; ++n )
                yield return string.Format (format, start + n);
        }
    }
    static void Main ()
    {
        foreach ( string s in NumberedStringEnumerator ("Identifier{0:2D}.xml", 1, 5) )
            Console.WriteLine (s);
    }
