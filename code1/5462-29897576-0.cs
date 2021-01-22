    using (var db = new DbContext())
    {
        if(db.State == State.Closed) throw new Exception("Database connection is closed.");
        return db.Something.ToList();
    }
