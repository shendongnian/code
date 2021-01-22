    // Returns a list of data source names from the local machine.
    public System.Collections.SortedList GetAllDataSourceNames()
    {
        // Get the list of user DSN's first.
        System.Collections.SortedList dsnList = GetUserDataSourceNames();
    
        // Get list of System DSN's and add them to the first list.
        System.Collections.SortedList systemDsnList = GetSystemDataSourceNames();
        for (int i = 0; i < systemDsnList.Count; i++)
        {
            string sName = systemDsnList.GetKey(i) as string;
            DataSourceType type = (DataSourceType)systemDsnList.GetByIndex(i);
            try
            {
                // This dsn to the master list
                dsnList.Add(sName, type);
            }
            catch 
            { 
                // An exception can be thrown if the key being added is a duplicate so 
                // we just catch it here and have to ignore it.
            }
        }
    
        return dsnList;
    }
