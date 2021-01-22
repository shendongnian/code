    string connectionString = "user id=dbblabla;" + 
                            "password=1234;server=localhost\\SQLEXPRESS;" + 
                            "Trusted_Connection=yes;" + 
                            "database=myDB; " + 
                            "connection timeout=30";
    DataSet ds = new DataSet();
    using(SqlConnection myConnection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand("yourprocedure", myConnection))
    {
        SqlDataAdapter myAdapter = new SqlDataAdapter();
        myAdapter.SelectCommand = command;
        myAdapter.Fill(ds,"AllInfo");
    }
    dataGridSearchOutput.DataSource = ds.Tables["AllInfo"].DefaultView;
