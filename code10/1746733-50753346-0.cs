    private void function(IDbContextFactory dbContextFactory)
    {
        using (var dbContext = dbContextFactory.Create())
        {
            // talk to sql here
        }
    }
