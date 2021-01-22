            TransactionOptions Opts = new TransactionOptions();
            Opts.IsolationLevel = IsolationLevel.ReadUncommitted;
            // start Transaction
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew, Opts))
            {
                // Do your work and call complete
                ts.Complete();
            }
