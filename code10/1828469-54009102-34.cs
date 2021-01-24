    public ICommand OpenFileCommand { get => new RelayCommand(OpenFile, CanOpenFile); }  
  
    private void OpenFile(string filePath)
    {
       ...
    }
    
    private bool CanOpenFile(string filePath)
    {
       return File.Exists(filePath);
    }
    public ICommand OpenFolderCommand { get => new RelayCommand(OpenFolder, CanOpenFolder); }
    
    private void OpenFolder(string folderPath)
    {
       ...
    }
    
    private bool CanOpenFolder(string folderPath)
    {
       return Directory.Exists(filePath);
    }
