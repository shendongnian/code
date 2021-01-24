    using (OracleConnection conn = new OracleConnection())
    {
            conn.ConnectionString = connectionstring;
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Insert into PFC.Trial(FAME)VALUES(:FAME)";
            cmd.Parameters.Add(new OracleParameter("FAME", TextBox1.Text));
            cmd.ExecuteNonQuery();     
    }
