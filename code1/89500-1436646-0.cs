        using (TransactionScope ts = new TransactionScope())
        {
            try
            {
                //delete some data
                db.SubmitChanges();
                ts.Complete();
            }
            catch (Exception ex)
            {
                // handle error
            }
            finally
            {
                db.Dispose();
            }
        }
        BindGridView();
