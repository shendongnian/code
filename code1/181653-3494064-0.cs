    public static int GetRealHashCode(this OleDbConnectionStringBuilder target)
    {
        int ToReturn = 17;
        ToReturn *= target.DataSource.TrimEnd(';').GetHashCode();
        ToReturn *= target.Provider.TrimEnd(';').GetHashCode();
        ToReturn *= target.PersistSecurityInfo.ToString().GetHashCode();
    
        var OrderedKeys = from string key in target.Keys
                  orderby key
                  select key;
        foreach (string Key in OrderedKeys)
            ToReturn *= target[Key].GetHashCode();
    
        return ToReturn;
    }
