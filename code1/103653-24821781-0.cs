    public static void MyFunction(MyErrorClass err)
    {
        var query = DataContext.ErrorFilters;
        query = query.Where(f => err.ErrorMessage.IndexOf(f.ErrorMessage)>=0);
        List<ErrorFilter> filters = query.ToList();
        //...more code
    }
