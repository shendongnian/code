    using System.Data.DataSetExtensions;
    ...
    List<MyObject> list = (from row in table.AsEnumerable()
                           select new MyObject
                           {
                                Foo = row.Field<string>("foo"),
                                Bar = row.Field<int>("bar")
                           }).ToList();
