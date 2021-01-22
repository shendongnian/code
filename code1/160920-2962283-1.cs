    public static string getInsertSQL(string tablename, params KeyValuePair<string, string>[] columns)
    {
        string strSQL = "INSERT INTO {0} ({1}) VALUES ({2})";
        string fields = String.Empty;
        string values = String.Empty;
        foreach (KeyValuePair<string, string> column in columns)
        {
         if (!String.IsNullOrEmpty(fields)) fields += ", ";
         if (!String.IsNullOrEmpty(values)) values += ", ";
         fields += column.Key;
         values += "\"" + column.Value + "\""; //Highly recommend replacing with parameters, or at least SQL escaping
        }
        return String.Format(strSQL, tablename, fields, values);
    }
