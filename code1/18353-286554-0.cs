    using ( FileStream fileStream = new FileStream( file, FileMode.Open, FileAccess.Read ) )
    {
        using ( StreamReader streamReader = new StreamReader( fileStream ) )
        {
            string line = "";
            while ( null != ( line = streamReader.ReadLine() ) )
            {
                Console.WriteLine( line );
            }
        }
    }
