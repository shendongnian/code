    public ICommand OpenFileCommand { get => new RelaisCommand(OpenFile, CanOpenFile); }
    
    private void OpenFile(string filePath)
    {
       ...
    }
    
    private bool CanOpenFile(string filePath)
    {
       return File.Exists(filePath);
    }
