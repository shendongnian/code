    public static bool UpdateRoleUser(int component_type, string oldRole, string oldUser, string oldAuth_value, string newRole, string newUser, string newAuth_value)
    {
    bool saved = false;
    using (var transaction = new System.Transactions.TransactionScope())
    {
      try
      {
        var db = new VMIEntities();
        db.usp_UpdateRoleUser(newRole, newUser, newAuth_value, oldRole, oldUser, oldAuth_value, component_type);
       
        context.SaveChanges();
        saved = true;
      }
      catch(OptimisticConcurrencyException e)
      {
        //Handle the exception
        context.SaveChanges();
      }
      finally
      {
        if(saved)
        {
          transaction.Complete();
          context.AcceptAllChanges();
        }
      }
    
    
    }
    }
