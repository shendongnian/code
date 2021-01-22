    List<MyType> listName = dataTableName.AsEnumerable().Select(m => new MyType()
    {
       ID = m.Field<string>("ID"),
       Description = m.Field<string>("Description"),
       Balance = m.Field<double>("Balance"),
    }).ToList()
