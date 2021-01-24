    var db = new DataClasses1DataContext(@"Data Source=");   
    var testTableRecord1 = new testTable();
    db.GetTable<testTable>().InsertOnSubmit(testTableRecord1);
    db.SubmitChanges();
    
    db = new DataClasses1DataContext(@"Data Source=");    
    var testTableRecord2 = new testTable();
    db.GetTable<testTable>().InsertOnSubmit(testTableRecord2);
    db.SubmitChanges();
