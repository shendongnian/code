    private static T ConvertStringToEnum<T>(string stringValue) where T : struct
    {
        if (System.Enum.TryParse(stringValue, out T result))
        {
            if (System.Enum.IsDefined(typeof(T), result) || result.ToString().Contains(","))
                return result;
            throw new System.Exception($"{stringValue} is not an underlying value of the {typeof(T).FullName} enumeration.");
        }
        throw new System.Exception($"{stringValue} is not a member of the {typeof(T).FullName} enumeration.");
    }
