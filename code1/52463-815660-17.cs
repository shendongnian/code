    using (TransactionScope scope = new TransactionScope())
    {
        //Do something with context1
        //Do something with context2
    
        //Save Changes but don't discard yet
        context1.SaveChanges(false);
    
        //Save Changes but don't discard yet
        context2.SaveChanges(false);
    
        //if we get here things are looking good.
        scope.Complete();
        context1.AcceptAllChanges();
        context2.AcceptAllChanges();
    }
