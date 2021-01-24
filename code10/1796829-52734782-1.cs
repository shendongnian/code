    public string SortenedFolderName => Path.GetFileName(_folderName);
    private string _folderName;
    public string FolderName
    {
       get { return _folderName; }
       set
       {
            _folderName = value;
            OnPropertyChanged(nameof(FolderName));
            OnPropertyChanged(nameof(SortenedFolderName));
        }
    } 
