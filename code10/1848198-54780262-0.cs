    class MyType{
       public int Positiondesc { get; set; }
    }
    List<MyType> listName = dataTableName.AsEnumerable().Select(m => new 
    MyType()
    {
       Positiondesc = m.Field<int>("positiondesc")
    }).ToList();
