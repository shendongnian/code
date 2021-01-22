    public static IList GetQueryResults(string xpathQuery, Type itemType) {
        Type tp = typeof(List<>).MakeGenericType(itemType);
        IList lst = (IList)Activator.CreateInstance(tp);
        return lst;
    }
