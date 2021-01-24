    using (context.Database.BeginTransaction())
    {
        context.EntityASet.Load();
        context.EntityBSet.Load();
        // …
    }
