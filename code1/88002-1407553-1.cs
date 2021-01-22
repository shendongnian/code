    using(var db = new MyDataContext())
    {
        var res = BQueries.Get(db, id);
        var entity = res.SingleOrDefault();
        // ...
    }
