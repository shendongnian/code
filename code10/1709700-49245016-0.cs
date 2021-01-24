               MySqlDataReader reader = cmd.ExecuteReader();
        
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                       outColumn.Add(reader[i].ToString());
                    }
                }
               
