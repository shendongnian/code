    using (aDataContext db = new aDataContext())
    {
       var dbItem = db.MatchUpdateQueues.Single(i => i.Id == item.Id);
       db.MatchUpdateQueues.DeleteOnSubmit(dbItem);
       db.SubmitChanges();
    }
