        using (var dbContextTransaction = PdmContext.Database.BeginTransaction())
                {
                    try
                    {
                       // HERE your operation insert etc.
                        PdmContext.SaveChanges();
                        dbContextTransaction.Commit(); // here, apply your operation
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback(); // here, undo your operations
                    }
                }
