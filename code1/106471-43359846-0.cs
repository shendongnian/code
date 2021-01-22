    string temp="";
    
    public void Initialize()
    {
       FileSystemWatcher _fileWatcher = new FileSystemWatcher();
      _fileWatcher.Path = "C:\\Folder";
      _fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
      _fileWatcher.Filter = "Version.txt";
      _fileWatcher.Changed += new FileSystemEventHandler(OnChanged);
      _fileWatcher.EnableRaisingEvents = true;
    }
    
    private void OnChanged(object source, FileSystemEventArgs e)
    {
       .......
    if(temp=="")
    {
       //do thing you want.
       temp = e.name //name of text file.
    }else if(temp !="" && temp != e.name)
    {
       //do thing you want.
       temp = e.name //name of text file.
    }else
    {
      //second fire ignored.
    }
    
    }
