    public static bool DoesRecordExist(string[] keyColumns, string[] keyValues, DataTable dt)
    {
        if (dt != null && dt.Rows.Count > 0)
        {       
            bool exists = dt.AsEnumerable()
                .Where(r => keyColumns.Zip(keyValues, 
                    (c, v) => string.Equals(SafeTrim(r[c]), v, StringComparison.CurrentCultureIgnoreCase))
                        .All()).Any();
            return exists;
        }
        else
        {
            return false;
        }
    }
