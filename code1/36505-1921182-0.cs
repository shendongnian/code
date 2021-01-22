    public static bool TryGetValue<T>(string key, out T value, IFormatProvider provider)
    {
        string queryStringValue = HttpContext.Current.Request.QueryString[key];
    
        if (queryStringValue != null)
        {
            // Value is found, try to change the type
            try
            {
                value = (T)Convert.ChangeType(queryStringValue, typeof(T), provider);
                return true;
            }
            catch
            {
                // Type could not be changed
            }
        }
    
        // Value is not found, return default
        value = default(T);
        return false;
    }
