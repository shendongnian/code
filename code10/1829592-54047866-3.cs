    public static bool DoesRecordExist(string[] keyColumns, string[] keyValues, DataTable dt)
    {
        if (dt != null && dt.Rows.Count > 0)
        {       
            bool exists = dt.AsEnumerable()
                .Where(r => keyColumns.Zip(keyValues, 
                    (col, val) => string.Equals(SafeTrim(r[col]), val, StringComparison.CurrentCultureIgnoreCase))
                        .All()).Any();
            return exists;
        }
        else return false;
    }
