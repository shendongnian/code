    // Start transaction
    MySqlTransaction transaction = connection.BeginTransaction();
    MySqlCommand command = new MySqlCommand();
    command.Connection = connection;
    command.Transaction = transaction;
    // Parent record
    command.CommandText = "INSERT INTO film(Title, Director, Year, Category) VALUES (@Title, @Director, @Year, @Category) ";
    command.Parameters.Add(new MySqlParameter("@Title", fm.Title));
    command.Parameters.Add(new MySqlParameter("@Director", fm.Director));
    command.Parameters.Add(new MySqlParameter("@Year", fm.Year));
    command.Parameters.Add(new MySqlParameter("@Category",n));
    command.ExecuteNonQuery();
    // Child record        
    command.CommandText = "INSERT INTO record (Film_id) VALUES (LAST_INSERT_ID())";
    command.ExecuteNonQuery();
    // Commit inserts
    transaction.Commit();
