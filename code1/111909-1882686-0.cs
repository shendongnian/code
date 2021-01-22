        IDataSource source = (IDataSource)myLinqDataSource;
        LinqDataSourceView view = source.GetView("DefaultView") as LinqDataSourceView;
        DataSourceSelectArguments args = new DataSourceSelectArguments();
        args.RetrieveTotalRowCount = view.CanRetrieveTotalRowCount;
        args.SortExpression = view.OrderBy;
        List<MyObject> objects = view.Select(args) as List<MyObjects>;
