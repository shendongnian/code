    using (TransactionScope scope = new TransactionScope())
    {
        Db1Container db1 = new Db1Container();
    
        try
        {
            db1.AddToTabella(new Tabella()
            {
                Valore = 1
            });
            db1.SaveChanges();
    
            db1.AddToTabella(new Tabella()
            {
                Valore = 1
            });
            db1.SaveChanges(); //Unique constraint is violated here and an exception is thrown
    
            //if we get here then there were no errors thrown on previous SaveChanges() 
            //calls and we can complete the transaction with no rollback
    	    scope.Complete();
        }
    	catch (Exception)
    	{
    	    //do nothing
    	}
   
    }
