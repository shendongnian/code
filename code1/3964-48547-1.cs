    public static bool IsNotEmpty ( this dataset ) 
    {
        return dataSet != null && (
            from DataTable t in dataSet.Tables 
            where t.Rows.AsQueryable().Any()
            select t).AsQueryable().Any();
    }
    //then the check would be
    DataSet ds = /* get data */;
    
    ds.IsNotEmpty();
