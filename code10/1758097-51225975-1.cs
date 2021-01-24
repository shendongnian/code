    // T1 -> Type of variableOne
    // T2 -> Type of variableTwo
    // T3 -> KeyValuesPair type
    public static Dictionary<T1, T2> convert<T1,T2,T3>(T3[] data)
    {
        // Instantiate dictionary to return
        Dictionary<T1, T2> dict = new Dictionary<T1, T2>();
        // Run through array
        for (var i = 0;i < data.Length;i++)
        {
            // Get 'key' value via Reflection to variableOne
            var key = data[i].GetType().GetProperty("variableOne").GetValue(data[i], null);
            // Get 'value' value via Reflection to variableTow
            var value = data[i].GetType().GetProperty("variableTwo").GetValue(data[i], null);
            // Add 'key' and 'value' to dictionary casting to properly type
            dict.Add((T1)key, (T2)value);
        }
        //return dictionary
        return dict;
    }
