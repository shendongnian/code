    using (TransactionScope scope = new TransactionScope())
    {
        //Do something with context1
        //Do something with context2
    
        //Save and discard changes
        context1.SaveChanges();
    
        //Save and discard changes
        context2.SaveChanges();
    
        //if we get here things are looking good.
        scope.Complete();
    }
