    private string _fileSearchPattern;
    private List<string> _files;
    private object lockThis = new object();
    
    public List<string> GetFileList(string fileSearchPattern, string rootFolderPath)
    {
    	_fileSearchPattern = fileSearchPattern;
    	AddFileList(rootFolderPath);
    	return _files;
    }
    
    private void AddFileList(string rootFolderPath)
    {
    	var files = Directory.GetFiles(rootFolderPath, _fileSearchPattern);
    	lock (lockThis)
    	{
    		_files.AddRange(files);
    	}
    
    	var directories = Directory.GetDirectories(rootFolderPath);
    
    	Parallel.ForEach(directories, AddFileList); // same as Parallel.ForEach(directories, directory => AddFileList(directory));
    }
