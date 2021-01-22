    public static T FetchValue<T>(string key) where T : IConvertible
    {
        string value;  
        // logic to set value here  
        // ...  
        return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);  
    }
