    using(SqlConnection con = new SqlConnection("user id=dbblabla;password=1234;server=localhost\\SQLEXPRESS; database=myDB; connection timeout=30"))
            {
                SqlCommand cmd = new SqlCommand("procedure",con);
                cmd.CommandType= System.Data.CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridSearchOutput.DataSource = dt;           
    
            }
