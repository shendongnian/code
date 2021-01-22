    public static T ConvertStringToEnum<T>(string text)
    {
        T returnVal;
        try
        {
            returnVal = (T) Enum.Parse( typeof(T), text, true );
        }
        catch( ArgumentException )
        {
            returnVal = default(T);
        }
        return returnVal;
    }
