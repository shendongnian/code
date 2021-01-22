    MyDataContext db = new MyDataContext();
    
    if (db.table.Where( x => x.ID == id).ToList().Count == 0 )
    {
    db.table.Add(MyRow);
    context.SubmitChanges();
    }
