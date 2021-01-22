    using( Stream stream = File.Open(fileName, FileMode.Open) )
    {
        using( StreamReader reader = new StreamReader(fileStream) )
        {
            string line = null;
            for( int i = 0; i < myLineNumber; ++i )
            {
                line = reader.ReadLine();
            }
        }
    }
