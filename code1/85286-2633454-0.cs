    public static DataTable GetLookupTable(String where, Int32 topRows)
    {
        DataTable tbl = null;
    
        Boolean hasOverride = hasMethodOverride("GetLookupTable");
    
        if (hasOverride)
        {
            tbl = invokeStaticMethod<T>(
                "GetLookupTable", new Object[2] { where, topRows })
                as DataTable;
        }
        else
        {
            tbl = doExtremelyCleverStuffToFetchData(where, topRows);
        }
    
        return tbl;
    }
