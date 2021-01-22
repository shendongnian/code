    public static T? ParseNummableEnum<T>(this string theValue)
    {
        return theValue.ParseNullableEnum<T>(ParseFailBehavior.ReturnNull);
    }
    public static T? ParseNullableEnum<T>(this string theValue, 
        ParseFailBehavior desiredBehavior) where T:struct
    {
        try
        {
            return (T?) Enum.Parse(typeof (T), theValue);
        }
        catch (Exception)
        {
            if(desiredBehavior == ParseFailBehavior.ThrowException) throw;
        }
        return desiredBehavior == ParseFailBehavior.ReturnDefault ? (T?)default(T) : null;
    }
