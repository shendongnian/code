    public ICommand OpenFolderCommand {get;} = new RelayCommand(p => OpenFolder());
    
    private string _foldernameWithPath;
    public string FoldernameWithPath
    {
        get { return _foldernameWithPath; }
        set
        {
            if (value == _foldernameWithPath) return
            _foldernameWithPath = value;
            OnPropertyChanged("FoldernameWithPath");
        }
    }
    public void OpenFolder()
    {
       FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
       if (openFolderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
       {
          FoldernameWithPath = openFolderDialog.SelectedPath;
       }
    }
