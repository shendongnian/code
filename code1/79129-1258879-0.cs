    public static class OraProvider
        {
            private static Dictionary<string, DataTable> _cachedDateTable; 
            ...
            public static DataTable GetTable(string Table, bool cache)
            {
                if (cache && _cachedDateTable.ContainsKey(Table))
                {
                    return _cachedDateTable[Table];
                }
                if (Connection.State == ConnectionState.Open)
                {
                    DataTable dt = new DataTable(Table);
                    
                    commonCommand.CommandText = "SELECT * FROM " + Table;
                    commonCommand.Connection = Connection;
                    commonDataAdapter.Fill(dt);
                    if (cache)
                    {
                        _cachedDateTable.Add(Table, dt);
                    }
                    else
                    {
                        if (_cachedDateTable.ContainsKey(Table))
                        {
                            _cachedDateTable.Remove(Table);
                            _cachedDateTable.Add(Table, dt);
                        }
                    }
                    return dt;
                }
                else
                {
                    return null;
                }
            }
    ...
    }
