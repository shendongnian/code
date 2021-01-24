    using (SqlConnection connection = new SqlConnection(conn))
                        {
                            connection.Open();
                            SqlCommand mycommand = new SqlCommand("select * from mytable",connection);
                           // SqlDataReader dataReader = mycommand.ExecuteReader();
                            DataTable dt = new DataTable();
                            dt.Load(mycommand.ExecuteReader());
                            string value = "me@live.com";
                            DataView dv = new DataView(dt);
                            dv.RowFilter = "email LIKE %'" + value + "'%";
        
                            dataGridView1.DataSource = dv.ToTable();
                          //  dataGridView1.DataSource = dt;
        
        
                        }
    
        
