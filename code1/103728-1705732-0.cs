    for (int ii = 1; ii < 200000; ii++)
    {
        using (var dc = new PlayDataContext())
        {
            var record = 
                (from r in dc.T1s where r.Id == ii select r).SingleOrDefault();
            if (record != null)
            {
                record.Name = "S";
                dc.SubmitChanges();
            }
        }
    }
