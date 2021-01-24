    using (OleDbConnection connection = new OleDbConnection(cs))
    {
        connection.Open();
        using (OleDbCommand cmd = new OleDbCommand(queryString, connection))
        {
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                StringBuilder body = new StringBuilder();
                while (reader.Read())
                {
                    string to = reader.GetString(0);
                    message.To.Add(to);
                    body.AppendFormat("The Employee id is 5 {0}<br>", to);
                }
                message.Body = body.ToString();
                reader.Close();
            }
        }
    }
    smtp.Send(message);
