    using (var scope = new TransactionScope(TransactionScopeOption.Required))
    {
          using (var del = new PdmContext())
          {
              DeleteModel.deleteFromAllTables();
          }
          db.SaveChanges();
     
          scope.Complete();  // commits the transaction     
    }
