    public static bool ReaderContainsColumn(IDataReader reader, string name)
    {
        for (int i = 0; i < reader.FieldCount; i++) {
            if (reader.GetName(i).Equals(name, StringComparison.CurrentCultureIgnoreCase)) return true; 
        }
        return false;
    }
