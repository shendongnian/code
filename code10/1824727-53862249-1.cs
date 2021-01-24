    using (SqlConnection connection = new SqlConnection(conn))
    {
      connection.Open();
      var query = "select * from mytable WHERE email = 'me@live.com'";
      SqlCommand mycommand = new SqlCommand(query,connection);
      // SqlDataReader dataReader = mycommand.ExecuteReader();
      DataTable dt = new DataTable();
      dt.Load(mycommand.ExecuteReader());
      DataView dv = new DataView(dt);
      dataGridView1.DataSource = dv.ToTable();
      // dataGridView1.DataSource = dt;
    }
