    context.Database.Connection.Open();
    try
    {
        context.EntityASet.Load();
        context.EntityBSet.Load();
        // …
    }
    finally
    {
        context.Database.Connection.Close();
    }
