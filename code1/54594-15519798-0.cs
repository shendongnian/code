    public static IEnumerable<MyObject> WhereQuery(IEnumerable<MyObject> source, string columnName, string propertyValue)
             {
                 return source.Where(m => { return m.GetType().GetProperty(columnName).GetValue(m, null).ToString().StartsWith(propertyValue); });
    
     }
