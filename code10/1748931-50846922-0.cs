    using (var tx = new TransactionScope())
    {
      using (var context = new MyDbContext())
      {
         var newEntity = populateNewEntity();
         context.MyEntities.Add(newEntity);
         context.SaveChanges();
         int entityId = newEntity.EntityId; // Fetches the identity value.
      }
    } // Rolls back the transaction. Entity not committed.
