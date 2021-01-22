    private IEnumerable<Tuple<string,string,string>> GetMessages()
    {
    using (var connection = new SqlConnection("connection string")
    using (var command = connection.CreateCommand())
    {
        command.CommandText = "SELECT Name, MailID, Body FROM table";
    
        connection.Open()
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                yield return new Tuple<string,string,string>(
                    reader.GetString(0), // name
                    reader.GetString(1) // email
                    reader.GetString(2)); // body
            }
        }
    }
    }
    foreach(var tuple in GetMessages())
    {
        SendMessage(tuple.Item1, tuple.Item2, tuple.Item3);
    }
    private void SendMessage(string name, string email, string body)
    {
         // use either Darin's or Albin's solution
    }
