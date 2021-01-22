    public IList<election> GetElections()
    {
        using (ormDataContext context = new ormDataContext(connStr))
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<election>(e => e.election_status);
            context.DeferredLoadingEnabled = false;
            context.LoadOptions = dlo;   
            return context.elections.ToList();
        }
    }
