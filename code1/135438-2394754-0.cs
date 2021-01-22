    public static bool TryParse<T>(this Enum theEnum, string valueToParse, out T returnValue)
    {
        returnValue = default(T);
        int intEnumValue;
        if (Int32.TryParse(valueToParse, out intEnumValue))
        {
            if (Enum.IsDefined(typeof(T), intEnumValue))
            {
                returnValue = (T)(object)intEnumValue;
                return true;
            }
        }
        return false;
    }
