        MySqlCommand cmd = new MySqlCommand("DeleteMessage", new MySqlConnection(GetConnectionString()));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new MySqlParameter("param1", MessageItem.Entry_ID));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
