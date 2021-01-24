    public static bool DoesRecordExist(DataTable dt, params string[] parameters)
    {
        bool exists = false;
        if (parameters.Length % 2 != 0 )
            throw new ArgumentException();
        if (dt == null || dt.Rows.Count == 0)
            return false;
        var query = dt.AsEnumerable()
        for (int i = 0; i < parameters.Length; i += 2)
            query = query.Where(r => string.Equals(SafeTrim(r[parameters[i]]),
                parameters[i + 1], StringComparison.CurrentCultureIgnoreCase)) ; 
        return exists;
    }
