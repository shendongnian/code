    connection.Open();
    cmd.ExecuteNonQuery();
    reader = cmd.ExecuteReader();
    cmd.CommandType = System.Data.CommandType.Text;
    while (reader.Read() != false)
    {
        
        Console.WriteLine(reader["char_name"]);
        Console.WriteLine(reader["level"]);
    }
    Console.ReadLine();
