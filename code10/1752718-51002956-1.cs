     protected void Button1_Click(object sender, EventArgs e)
            {
                using (var dbTransactionContext = context.Database.BeginTransaction())
                {
                    //then do the operation
                }
            }
