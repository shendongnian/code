    public static T Convert<T>(this string input)
    {
        try
        {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if(converter != null)
                {
                    // Cast ConvertFromString(string text) : object to (T)
                    return (T)converter.ConvertFromString(input);
                }
        }
        catch (InvalidCastException)
        {
                return default(T);
        }
    }
