    private static string _data = "";
    public static string _Data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
            NotifyStaticPropertyChanged(nameof(_Data));
        }
    }
    public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
    private static void NotifyStaticPropertyChanged(string propertyName)
    {
        if (StaticPropertyChanged != null)
            StaticPropertyChanged(null, new PropertyChangedEventArgs(propertyName));
    }
