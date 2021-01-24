    public static event PropertyChangedEventHandler PropertyChanged;
    
    private static void NotifyPropertyChange<T>(Expression<Func<T>> property)
    {
        string propertyName = (((MemberExpression) property.Body).Member as PropertyInfo).Name;
        PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
    }
