    public static T Parse<T>(object value)
    {
        //convert value to string to allow conversion from types like float to int
        //converter.IsValid only works since .NET4, still incorrectly returns true for value null for type Unit, handled by logic below
        var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
        return value == null || !converter.IsValid(value.ToString()) ? default(T) : (T)converter.ConvertFrom(value.ToString());
    }
