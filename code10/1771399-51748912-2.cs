    bool ispms = ...
    using (var dbContext = GetDbContext(ispms)
    {
         var fetchedClient = dbContext.Clients
             .Where(client => ...)
             .FirstOrDefault();
         if (fetchedClient != null)
         {
              fetchedClient.Name = ...
              dbContext.SaveChanges();
         }
    }
