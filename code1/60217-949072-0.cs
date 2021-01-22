            // start transaction
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                using (SharedDbConnectionScope scope = new SharedDbConnectionScope(DB._provider))
                {
                    try
                    {
                        Record r = new InlineQuery().ExecuteAsCollection<RecordCollection>(
                            String.Format("SELECT * FROM {0} WHERE {1} = ?param FOR UPDATE",
                                            Record.Schema.TableName,
                                            Record.Columns.Column1), "VALUE")[0];
                        // do something
                        r.Save();
                     }
                 }
             }
