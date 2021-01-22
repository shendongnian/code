    private static object GetSessionValue([CallerMemberName]string propertyName = "") 
    {
        return Session[propertyName];
    }
    private static void SetSessionValue(object value, [CallerMemberName]string propertyName = "") 
    {
        Session[propertyName] = value;
    }
    public int MyIndex
    {
        get { return (int)GetSessionValue(); }
        set { SetSessionValue(value); }
    }
