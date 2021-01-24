        internal int SaveChangesInternal(SaveOptions options, bool executeInExistingTransaction)
        {
            AsyncMonitor.EnsureNotEntered();
            PrepareToSaveChanges(options);
            var entriesAffected = 0;
            // if there are no changes to save, perform fast exit to avoid interacting with or starting of new transactions
            if (ObjectStateManager.HasChanges())
            {
                if (executeInExistingTransaction)
                {
                    entriesAffected = SaveChangesToStore(options, null, startLocalTransaction: false);
                }
                else
                {
                    var executionStrategy = DbProviderServices.GetExecutionStrategy(Connection, MetadataWorkspace);
                    entriesAffected = executionStrategy.Execute(
                        () => SaveChangesToStore(options, executionStrategy, startLocalTransaction: true));
                }
            }
            ObjectStateManager.AssertAllForeignKeyIndexEntriesAreValid();
            return entriesAffected;
        }
