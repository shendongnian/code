        SqlDataReader reader = command.ExecuteReader();
        while (reader.HasRows)
        {
             Console.WriteLine("\t{0}\t{1}", reader.GetName(0),reader.GetName(1));
        
             while (reader.Read())
             {
                 Console.WriteLine("\t{0}\t{1}", reader.GetInt32(0),
                            reader.GetString(1));
             }
             reader.NextResult();
        }
