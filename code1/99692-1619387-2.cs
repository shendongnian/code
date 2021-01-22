    // INotifyPropertyChanged interface implementation and plumbing
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    protected virtual void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName);
    }
    
    // The property you are going to bind to
    
    private string _messageText = String.Empty;
    
    public string MessageText
    {
      get { return _messageText; }
      set
      {
        _messageText = value;
        OnPropertyChanged("MessageText");
      }
    }
    
    // How to modify your code to update the bindable property
    
    private void OnMessageReceive(string message) // assuming this method already exists
    {
      MessageText = MessageText + Environment.NewLine + message;
    }
