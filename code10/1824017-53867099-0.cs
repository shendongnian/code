    SqlCommand cmd = new SqlCommand("select * from foo where bar = @BAR", conn);
    cmd.Parameters.Add(new SqlParameter("@BAR", SqlDbType.VarChar));
    cmd.Parameters[0].Value = TNom.Text;
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataTable dt = new DataTable();
    da.Fill(dt);
    dataGridView1.DataSource = dt;
