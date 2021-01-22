    protected void Button1_Click(object sender, EventArgs e)
       {
           using (SqlConnection connection1 = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;User Instance=True"))
           {
               connection1.Open();
               // Start a local transaction.
               SqlTransaction sqlTran = connection1.BeginTransaction();
               // Enlist a command in the current transaction.
               SqlCommand command = connection1.CreateCommand();
               command.Transaction = sqlTran;
               try
               {
                   // Execute two separate commands.
                   command.CommandText =
                    "insert into [doctor](drname,drspecialization,drday) values ('a','b','c')";
                   command.ExecuteNonQuery();
                   command.CommandText =
                    "insert into [doctor](drname,drspecialization,drday) values ('x','y','z')";
                   command.ExecuteNonQuery();
                   // Commit the transaction.
                   sqlTran.Commit();
                   Label3.Text = "Both records were written to database.";
               }
               catch (Exception ex)
               {
                   // Handle the exception if the transaction fails to commit.
                   Label4.Text = ex.Message;
                   
                   try
                   {
                       // Attempt to roll back the transaction.
                       sqlTran.Rollback();
                   }
                   catch (Exception exRollback)
                   {
                       // Throws an InvalidOperationException if the connection 
                       // is closed or the transaction has already been rolled 
                       // back on the server.
                       Label5.Text = exRollback.Message;
                       
                   }
               }
           }
           
       }
