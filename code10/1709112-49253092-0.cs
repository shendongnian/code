    private Labels _label;
    public Labels Label
    {
       get { return _label; }
       set
            {
                if (value != null)
                {
                    _label = value;
                    OnPropertyChanged("Label");
                }
            }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = this.PropertyChanged;
        if (handler != null)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            handler(this, e);
        }
    }
    protected void OnPropertyChanged<T>(Expression<Func<T>> propertySelector)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            string propertyName = GetPropertyName(propertySelector);
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
