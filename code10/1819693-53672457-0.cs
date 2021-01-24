    public void CreateNew(DBContext db, T newRec)
    {
        db.GetTable(typeof(T)).InsertOnSubmit(newRec);
        db.SubmitChanges();
    }
