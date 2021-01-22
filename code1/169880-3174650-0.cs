    For a database table with columns "ColumnA", "ColumnB" and "ColumnC"
    
    var myEntity = new EntityObject { ColumnA = "valueA", ColumnB = "valueB", "ColumnC" = "valueC" };
    DataContext.InsertOnSubmit(myEntity);
    DataContext.SubmitChanges();
