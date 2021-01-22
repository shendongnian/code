    Task.Factory.StartNew(() =>
        {
            List<string> serverNames = data.RetrieveServerNames();
            List<string> logNames = data.RetrieveLogNames();
            List<string> entryTypes = data.RetrieveEntryTypes();
            return Tuple.Create(serverNames, logNames, entryTypes);
        }).ContinueWith(antecedent =>
            {
                if (!antecedent.IsFaulted)
                {
                    ServerNames = KeepExistingFilter(ServerNames, antecedent.Result.Item1);
                    LogNames = KeepExistingFilter(LogNames, antecedent.Result.Item2);
                    EntryTypes = KeepExistingFilter(EntryTypes, antecedent.Result.Item3);
                }
            });
