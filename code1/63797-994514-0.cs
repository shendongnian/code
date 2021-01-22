    string ConnString = "Microsoft.Jet.OleDb.4.0;Data Source=|DataDirectory|Northwind.mdb";
    string SqlString = @"Select * From Contacts 
                        Where FirstName = @FirstName And LastName = @LastName";
    using (OleDbConnection conn = new OleDbConnection(ConnString))
    {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("LastName", txtLastName.Text);
            conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Response.Write(reader["FirstName"].ToString() + " " + reader["LastName"].ToString());
                }
            }
        }
    }
