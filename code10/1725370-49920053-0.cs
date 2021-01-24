    string connectionString = "Data Source=.;Initial Catalog=pubs;Integrated Security=True"; // put your connection string
        string sql = "SELECT * FROM Authors"; // change your table name
        SqlConnection connection = new SqlConnection(connectionString);
        SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
        DataSet ds = new DataSet();
        connection.Open();
        dataadapter.Fill(ds, "Authors_table");
        connection.Close();
        dataGridView1.DataSource = ds; // put your gridview name
        dataGridView1.DataMember = "Authors_table";
