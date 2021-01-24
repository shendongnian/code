    private void Sync(IPostDatabaseOperationEventArgs e)
    {
        e.Session.Transaction.RegisterSynchronization(new AfterTransactionCompletes(success =>
        {
            if (!success)
                return;
                
            // Do your stuff
        }));
    }
