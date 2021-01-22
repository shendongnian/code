           using (var ts = new TransactionScope())
            {
                using (SharedDbConnectionScope scope = new SharedDbConnectionScope())
                {
                    try
                    {
                        document.Save();
                        documentsDatum.DocumentId = 5;
                        documentsDatum.Save();
                        ts.Complete();
                    }
                    catch (Exception ex )
                    {
                        
                        throw new Exception("trx failed " + ex.Message, ex);
                    }
                }
            }
