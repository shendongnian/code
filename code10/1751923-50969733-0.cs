    public TreeItem FolderFiles 
    {
        get
        {
            return _folderFiles;
        }
        set
        {
            _folderFiles = value;
            OnPropertyChanged("FolderFiles");
        }
    }
