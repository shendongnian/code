    string _name;
    public string Name
    {
    get 
    {
       return _name;
    }
    set
    {
       _name = value;
       // Alert the databinding engine about changes to the source value
       OnPropertyChanged("Name");
    }
    void OnPropertyChanged(string propertyName)
    {
       if (PropertyChanged != null)
          PropertyChanged(propertyName);
    }
    #region INotifyPropertyChanged members
    public event PropertyChangedEventHandler PropertyChanged;
    #endregion
