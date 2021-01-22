    public event PropertyChangedEventHandler PropertyChanged;
    
    public string UserName
    {
        get { return _UserName; }
        set { if (value != _UserName)
        {
            _UserName = value;
            OnNotifyPropertyChanged("UserName");
        }}
    }
    
    private void OnNotifyPropertyChanged(string property)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(property));
    }
