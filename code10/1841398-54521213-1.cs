    var db = new DataClasses1DataContext(@"Data Source=");   
    var testTableRecord1 = new testTable(){ id = -1 };
    var testTableRecord2 = new testTable(){ id = -2 };
    db.GetTable<testTable>().InsertOnSubmit(testTableRecord1);
    db.SubmitChanges();
    db.GetTable<testTable>().InsertOnSubmit(testTableRecord2);
    db.SubmitChanges();
