    public void Insert<T>(T obj) where T : class
    {
         using (var db = GetData())
         {
             db.GetTable<T>().InsertOnSubmit(obj);
             db.SubmitChanges();
         }
    }
