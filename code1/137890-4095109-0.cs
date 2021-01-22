    public T GetValueAs<T>(string sValue)
        where T : struct
    {
        if (string.IsNullOrEmpty(sValue))
        {
            return default(T);
        }
        else
        {
            return (T)Convert.ChangeType(sValue, typeof(T));
        }
    }
