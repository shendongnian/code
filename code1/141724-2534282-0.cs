    using(var connection = new MySqlConnection("your connection string"))
    {
        using(var command = new MySqlCommand("INSERT INTO programs (name, id) VALUES (?name, ?id)", connection))
        {
            var nameParameter = new MySqlParameter("name");
            var idParameter = new MySqlParameter("id");
            
            command.Parameters.Add(nameParameter);
            command.Parameters.Add(idParameter);
    
            connection.Open();
    
            for(int i = 0; i < name.Length; i++)
            {
                 nameParameter.Value = name[i];
                 idParameter.Value = id[i];
    
                 command.ExecuteNonQuery();             
            }
            connection.Close(); //Dispose being called by the using should close connection, but it doesn't hurt to close it here/sooner either.         
        }
    }
