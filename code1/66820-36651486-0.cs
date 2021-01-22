    private static object GetValueFromSession([CallerMemberName]string propertyName = "") 
    {
        return Session[propertyName];
    }
    private static void SetValueInSession(object value, [CallerMemberName]string propertyName = "") 
    {
        Session[propertyName] = value;
    }
    public int MyIndex
    {
        get { return (int)GetValueFromSession(); }
        set { SetValueInSession(value); }
    }
