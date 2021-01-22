    List<string> _searchPatternList = new List<string>();
        ...
        List<string> fileList = new List<string>();
        foreach ( string ext in _searchPatternList )
        {
            foreach ( string subFile in Directory.GetFiles( folderName, ext  )
            {
                fileList.Add( subFile );
            }
        }
        
        // Sort alpabetically
        fileList.Sort();
    
        // Add files to the file browser control    
        foreach ( string fileName in fileList )
        {
            ...;
        }
