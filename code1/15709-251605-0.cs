    public static IList GetRecords(object dataItem) 
    {
        Type type = dataItem.GetType();
        return (IList) typeof(Populate).GetMethod("GetList")
            .MakeGenericMethod(type).Invoke(null,null);
    }
