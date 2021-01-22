    using (DataContext db = new DataContext())
    {
        db.Connection.Open();
        db.Transaction = db.Connection.BeginTransaction();
    
        try
        {
            foreach (string entry in entries)
            {
                ....
                db.XXXX.InsertOnSubmit(xxx);
                db.SubmitChanges();
            }
    
            db.Transaction.Commit(); <== CALL HERE !!
        }
        catch (Exception)
        {
            db.Transaction.Rollback();
        }
        finally
        {
            db.Connection.Close();
        }
    }
