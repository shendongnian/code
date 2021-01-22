    List<MyClass> result = myDataTable.AsEnumerable().Select(x=> new MyClass(){
         Property1 = (string)x.Field<string>("ColumnName1"),
         Property1 = (int)x.Field<int>("ColumnName2"),
         Property1 = (bool)x.Field<bool>("ColumnName3"),    
    });
