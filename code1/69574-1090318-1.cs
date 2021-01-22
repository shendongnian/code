    using ( Stream stream = new FileStream( @"C:\foo.txt", FileMode.Open ) )
    using ( TextReader reader = new StreamReader( stream ) )
    {
        string contents = reader.ReadToEnd( );
        contents = contents.Replace( "{", "" ).Replace( "}", "" );
        var values = new List<int>();
        foreach ( string s in contents.Split( ',' ) )
        {
            try
            {
                values.Add( int.Parse( s ) );
            }
            catch ( FormatException fe )
            {
                // ...
            }
            catch ( OverflowException oe )
            {
                // ...
            }
        }
    }
