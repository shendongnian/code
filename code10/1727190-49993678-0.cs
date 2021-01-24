    string connectionString = "your connection string here";
    string query = "select blah, foo from mytable where LogTime >= @parameter1 and LogTime<= @parameter2";
    DataSet ds = new DataSet();
    using (SqlCommand cmd = new SqlCommand(query, new SqlConnection(connectionString)))
    {
        cmd.Parameters.Add("parameter1", SqlDbType.DateTime).Value = dateInput1;
        cmd.Parameters.Add("parameter2", SqlDbType.DateTime).Value = dateInput2;
        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) {
            adapter.Fill(ds);
        }
    }
