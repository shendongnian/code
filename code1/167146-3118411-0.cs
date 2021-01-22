    var tableItem = new Table
    {
        Prop1 = var1
        Prop2 = var2,
        Prop3 = var3,
        ParentTable = db.Table.Where(t => Id == parentRecordID).First();
    };
    
    db.Table.AddObject(tableItem);
    db.SaveChanges();
