     SqlConnection con = new SqlConnection(@"Some Connection String");
     SqlDataAdapter da = new SqlDataAdapter("ParaEmp_Select",con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Contactid", SqlDbType.Int).Value = 123;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
