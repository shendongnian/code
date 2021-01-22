    GetParameterName2(new { variable });
    
    //Hack to assure compiler warning is generated specifying this method calling conventions
    [Obsolete("Note you must use a single parametered AnonymousType When Calling this method")]
    public static string GetParameterName<T>(T item) where T : class
    {
        if (item == null)
            return string.Empty;
        return typeof(T).GetProperties()[0].Name;
    }
