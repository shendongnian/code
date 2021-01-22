    using(TransactionScope scope = new Transactionscope())
    {
        try 
        {
            /* ... your current code here */
            scope.Complete();
        }
        catch (Exception e)
        {
            /* Any appropriate error handling/logging here */
        }
        finally
        {
        }
    }
