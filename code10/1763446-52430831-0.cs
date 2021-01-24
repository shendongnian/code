    List<myCustomerCLass> list = new List<myCustomerCLass>();
    
      con.Open();
    
        SqlCommand cmd = new SqlCommand("Select Name,Salary FROM YOUR TABLE", con);
    
        SqlDataReader dr = cmd.ExecuteReader();
    if (reader.HasRows)
            {
                while (reader.Read())
                {
    myCustomerCLass  test = new myCustomerCLass();
                    test.property1 = reader["Property1"]
    test.property2 = reader["Property2"]
    test.property3 = reader["Property3"]
    list.add(test);
                }
            }
           
            reader.Close();
        dataGridView1.DataSource = list;
        dataGridView1.DataBind();     // causing problem here
    
        con.Close();
