    using (TransactionScope ts = new TransactionScope())
    {
        using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())           
        {
                // update here
        }
    }
