    private string info { get; set; }
    public string Info
    {
        get { return info; }
        set
        {
            info = value;
            OnPropertyChanged();
        }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    private void OnPropertyChanged([CallerMemberName] string properName = null)
    {
        if(PropertyChanged != null)
        this.PropertyChanged(this,new PropertyChangedEventArgs(properName));
    }
