    // _zipFile = your ZipFile instance
    List<string> _folderNames = new List<string>();
    List<string> _fileNames = nwe List<string>();
    string _startPath = "";
    const string PATH_SEPARATOR = "/";
    
    foreach ( ZipEntry entry in _zipFile )
    {
    	string name = entry.Name;
    
    	if ( _startPath != "" )
    	{
    		if ( name.StartsWith( _startPath + PATH_SEPARATOR ) )
    			name = name.Substring( _startPath.Length + 1 );
    		else
    			continue;
    	}
    
    	// Ignore items below this folder
    	if ( name.IndexOf( PATH_SEPARATOR ) != name.LastIndexOf( PATH_SEPARATOR ) )
    		continue;
    
    	string thisPath = null;
    	string thisFile = null;
    
    	if ( entry.IsDirectory ) {
    		thisPath = name.TrimEnd( PATH_SEPARATOR.ToCharArray() );
        }
    	else if ( entry.IsFile )
    	{
    		if ( name.Contains( PATH_SEPARATOR ) )
    			thisPath = name.Substring( 0, name.IndexOf( PATH_SEPARATOR ) );
    		else
    			thisFile = name;
    	}
    
    	if ( !string.IsNullOrEmpty( thisPath ) && !_folderNames.Contains( thisPath ) )
    		_folderNames.Add( thisPath );
    
    	if ( !string.IsNullOrEmpty( thisFile ) && !_fileNames.Contains( thisFile ) )
    		_fileNames.Add( thisFile );
    }
