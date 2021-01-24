    static int? GetColumn(DbDataReader reader, string name)
    {
        for (int i = 0; i < reader.VisibleFieldCount; i++)
        {
            if (reader.GetName(i).Equals(name, StringComparison.InvariantCultureIgnoreCase))
            {
                return i;
            }
        }
        return null;
    }
