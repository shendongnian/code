            SqliteCommand command = connection.CreateCommand();
            SqlTransaction transaction = null;
            connection.Open();
            
            transaction = connection.BeginTransaction();
            
            command.Transaction = transaction;
            
            command.CommandText = "Insert bla";
            command.ExecuteNonQuery();
            command.CommandText = "Update bla";
            command.ExecuteNonQuery();
            
            transaction.Commit();
            connection.Close();
