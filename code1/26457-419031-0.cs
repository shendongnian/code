        using (var stats = DirStats.Create())
        {
            IEnumerable<string> allFiles = GetAllFiles();
            IEnumerable<string> matchingFiles = GetMatches( "*.txt", allFiles );
            IEnumerable<string> contents = GetFileContents( matchingFiles );
            stats.Print()
            IEnumerable<string> matchingLines = GetMatchingLines( contents );
            stats.Print();
        } 
