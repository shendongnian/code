    SqlConnection cn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    cn.ConnectionString = @"Data Source=localhost; Initial Catalog=Testing; Integrated Security = True"; // Changed
    List<string> str = new List<string>();
    cmd.Connection = cn;
    cmd.Connection.Open();
    cmd.CommandText = "SELECT distinct column1 FROM testTable"; // Changed
    SqlDataReader dr = cmd.ExecuteReader();  // Changed
    while (dr.Read())
    {
        str.Add(dr.GetValue(0).ToString());  // Changed
    }
    
    foreach (string p in str)
    {
        Response.Write(p);
    }
