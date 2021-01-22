    using (SqlDataReader reader = command.ExecuteReader()) {
      while (reader.Read()) {
         int id = (int)reader["ID"]; // or reader.GetInt(0);
         string name = reader["Name"].ToString(); // or reader.GetString(1);
      }
      reader.Close();
    }
