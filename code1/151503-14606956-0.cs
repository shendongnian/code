    Task.Factory.StartNew(() => data.RetrieveServerNames())
        .ContinueWith(antecedent1 =>
            {
                if (!antecedent1.IsFaulted)
                {
                    ServerNames = KeepExistingFilter(ServerNames, antecedent1.Result);
                    Task.Factory.StartNew(() => data.RetrieveLogNames())
                        .ContinueWith(antecedent2 =>
                            {
                                if (antecedent2.IsFaulted)
                                {
                                    LogNames = KeepExistingFilter(LogNames, antecedent2.Result);
                                    Task.Factory.StartNew(() => data.RetrieveEntryTypes())
                                        .ContinueWith(antecedent3 =>
                                            {
                                                if (!antecedent3.IsFaulted)
                                                {
                                                    EntryTypes = KeepExistingFilter(EntryTypes, antecedent3.Result);
                                                }
                                            });
                                }
                            });
                }
            });
