    Using(Datacontext dc = new Datacontext())
    {
        foreach(int id in lstIds.Items)
        {
            temp.Add(id);
        }
        dc.SubmitChanges();
    }
