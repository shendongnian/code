    var files = new Counter<string>( GetAllFiles());
    var matchingFiles = new Counter<string>(GetMatches( "*.txt", files ));
    var contents = GetFileContents( matchingFiles );
    var linesFound = new Counter<string>(GetMatchingLines( contents ));
    foreach( var lineText in linesFound )
        Console.WriteLine( "Found: " + lineText );
    string message 
        = String.Format( 
            "Found {0} matches in {1} matching files. Scanned {2} files",
            linesFound.Count,
            matchingFiles.Count,
            files.Count);
    Console.WriteLine(message);
