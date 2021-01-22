    // I'm going to go ahead and assume your Values property
    // is a Dictionary<string, object>
    public static T TryGetValue<T>(this Row row, string key, T defaultValue)
    {
        // objValue is declared as object, which is fine
        object objValue;
    
        // this is legal, since Values is a Dictionary<string, object>;
        // however, if TryGetValue returns true, it does not follow
        // that the value retrieved is necessarily of type T (string) --
        // it could be any object, including null
        if (row.Values.TryGetValue(key, out objValue))
        {
            // e.g., suppose row.Values contains the following key/value pair:
            // "Username", 10
            //
            // then what you are attempting here is (string)int,
            // which throws an InvalidCastException
            return (T)objValue;
        }
    
        return defaultValue;
    }
