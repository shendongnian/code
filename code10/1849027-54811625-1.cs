    private void LoadServerList(object parameter)
    {
        try
        {
            //throw new InvalidOperationException("test");
            ServerCollection.Clear();
            ///... Load();
            Error = string.Empty;
        }
        catch (InvalidOperationException ex)
        {
            Error = ex.Message;
        }
    }
    private string _error;
    public string Error
    {
        get { return _error; }
        set { _error = value; NotifyPropertyChanged(); }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
