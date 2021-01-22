    using System.Data;
    var myEnumerable = myDataTable.AsEnumerable();
    
    List<MyClass> myClassList =
        (from item in myEnumerable
         select new MyClass{
             MyClassProperty1 = item.Field<string>("DataTableColumnName1"),
             MyClassProperty2 = item.Field<string>("DataTableColumnName2")
        }).ToList();
