    using (SqlConnection conn = new SqlConnection("Connection String Goes Here"))
    {
        conn.Open();
        using (SqlCommand comm = new SqlCommand("SELECT * FROM TABLE", conn))
        {
            return command.ExecuteScalar() as string;
        }
    }
