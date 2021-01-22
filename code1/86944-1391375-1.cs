    using (DataContext db = new DataContext(_MyConnectionString))
    {
        foreach (Item record in db.Items)
        {
            record.Description += "bla";
        }
        db.SubmitChanges();
    }
