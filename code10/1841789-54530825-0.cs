    public IList<string> ReadLineByLineFromFile( string filePath )
    {
        const int numberOfRetries = 3;
        const int delayOnRetry = 500;
    
        bool success = false;
        List<string> logs = null;
    
        for ( int i = 0; i <= numberOfRetries && success == false; i++ )
        {
            try
            {
                logs = new List<string>();
    
                const Int32 bufferSize = 128;
                using ( var fileStream = File.Open( filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) )
                using ( var streamReader = new StreamReader( fileStream, Encoding.UTF8, true, bufferSize ) )
                {
                    string line;
    
                    while ( ( line = streamReader.ReadLine() ) != null )
                    {
                        logs.Add( line );
                    }
                }
    
                success = true;
            }
            catch ( IOException ex ) when ( i < numberOfRetries )
            {
                Local.Instance().Logger.Warn( ex, "Retrying reading logs from file path {0}, retry count {1} with dealy {2} ms.", filePath, i + 1,
                    delayOnRetry );
    
                System.Threading.Thread.Sleep( delayOnRetry );
            }
        }
    
        GC.Collect();
    
        return logs;
    }
