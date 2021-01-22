    public static T Parse<T>(object value)
    {
        value = value == null ? null : value.ToString(); //convert value to string to allow conversion from types like float to int
        var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
        return converter.IsValid(value) ? (T)converter.ConvertFrom(value) : default(T);
    }
