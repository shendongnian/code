    public static bool DoesRecordExist(DataTable dt, params string[] params)
    {
        bool exists = false;
        if (params.Length % 2 != 0 )
        throw new ArgumentException();
        if (dt == null || dt.Count == 0)
            return false;
        var query = dt.AsEnumerable()
        for (int i = 0; i < params.Length; i += 2)
        query = query.Where(r => string.Equals(SafeTrim(r[params[i]]), params[i + 1], StringComparison.CurrentCultureIgnoreCase))  
        return exists;
    }
