    public static T GetEnumFromString<T>(string strValue, T defaultValue)
    {
        // Check if it realy enum at runtime 
        if (!typeof(T).IsEnum)
            throw new ArgumentException("Method GetEnumFromString can be used with enums only");
    
        if (!string.IsNullOrEmpty(strValue))
        {
            IEnumerator enumerator = Enum.GetValues(typeof(T)).GetEnumerator();
            while (enumerator.MoveNext())
            {
                T temp = (T)enumerator.Current;
                if (temp.ToString().ToLower().Equals(strValue.Trim().ToLower()))
                    return temp;
            }
        }
    
        return defaultValue;
    }
