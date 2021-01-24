    string connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\WordssTable.mdb;
    Persist Security Info=False";
    using(OleDbConnection connectObj = new OleDbConnection(connectionStr))
    using(OleDbCommand command = new OleDbCommand())
    {
        connectObj.Open();
        command.Connection = connectObj;
        command.CommandText = "SELECT * FROM WordsTable WHERE EnglishWord=@text";
        command.Parameters.Add("@text", OleDbType.VarWChar).Value = hebw1.Text;
        using(OleDbDataReader reader = command.ExecuteReader())
        {
            // Try to read the first record, if any, and then update the labels
            if(reader.Read())
            {
                 hebw1.Text = reader["hebw1"].ToString();
                 hebw2.Text = reader["hebw2"].ToString();
                 hebw3.Text = reader["hebw3"].ToString();
                 hebw4.Text = reader["hebw4"].ToString();
            }
       }
    }
