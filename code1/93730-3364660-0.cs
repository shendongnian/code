    enter code here
          using (DataContext db = new DataContext())
            {
                // The dispose method of DbConnection will close any open connection
                // and will rollback any uncommitted transactions
                using (DbConnection dbConnection = db.Connection)
                {
                    dbConnection.Open();
                    db.Transaction = dbConnection.BeginTransaction();
                    foreach (string entry in entries)
                    {
                        XXX xxx = new XXX()
                        {
                            P1 = "something",
                            P2 = "something"
                        };
                        db.XXXX.InsertOnSubmit(xxx);
                    }
                    db.SubmitChanges();
                    db.Transaction.Commit();
                }
            } 
