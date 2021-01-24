    cmd.Connection = con;
    
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataTable dt = new DataTable();
    dt.Columns.Add("id", typeof(int));
    dt.Columns.Add("login", typeof(string));
    dt.Columns.Add("password", typeof(string));
    dt.Columns.Add("mail", typeof(string));
    da.Fill(dt);
    foreach (DataRow dr in dt.Rows)
    {
        RelacjaINT = Convert.ToInt32(dr["id"]);
    }
