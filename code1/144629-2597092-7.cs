    public ImplementationType getOne(Expression<Func<ImplementationType , bool> singleOrDefaultClause)
    { 
        ImplementationType  entity = null;
        if (singleOrDefaultClause != null) 
        {
      
            LCFDataContext lcfdatacontext = new LCFDataContext();
            //Generic LINQ Query Here
            entity = lcfdatacontext.GetTable<ImplementationType>().SingleOrDefault(singleOrDefaultClause);
            lcfdatacontext.Dispose();
        }
        return entity;
    }
