    public static List<T> getValues<T>(string ColName)
    {
        List<T> myReturnList = new List<T>();
        var selectedColumnValues = db.AC_PROPERTY.Select(ColName);
    
        //Query and add results to list. 
        return myReturnList;
    }
