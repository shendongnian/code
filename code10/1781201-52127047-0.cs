    public string Username
    {
        get { return username;}
        set { username = value; OnPropertyChanged("Username");
    }
    private string username = string.Empty;
    public ObservableCollection<Change> Changes
    {
        get { return changes; }
        set { changes = value; OnPropertyChanged("Changes");
    }
    private ObservableCollection<Change> changes = null;
