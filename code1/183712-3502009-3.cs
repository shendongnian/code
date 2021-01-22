    public static T StringToEnum(string stringToConvert, out bool success)
    {
        try
        {
            // Ensure the string is valid and not empty
            if (!String.IsNullOrEmpty(stringToConvert))
            {
                success = true;
                // Ignore case on the conversion
                return (T)Enum.Parse(typeof(T), stringToConvert, true);
            }
        }
        catch(ArgumentException ex)
        {
            // Use your own Exception Management Here
        }
        catch(InvalidCastException ex)
        {
            // Use your own Exception Management Here
        }
        success = false;
        return default(T);
    }
