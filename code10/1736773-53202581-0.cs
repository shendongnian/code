    private void BindGrid() 
    {
        //declare DataSet attribute
        SqlDataAdapter da;  
        DataSet ds = new DataSet(); 
   
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        con.ConnectionString = gc.GetWebConfigConnectionStringAIS();
        con.Open();
        string query = "SELECT ID_ FROM dbo.Testing";
        cmd = new SqlCommand(query, con);
        cmd.CommandType = CommandType.Text;
        //here happens the magic
        cmd.Connection = con;  
        da = new SqlDataAdapter(cmd);  
        da.Fill(ds);  
        cmd.ExecuteNonQuery();
        //using dataset instead of reader will resolve your issue
        Grid.DataSource = ds;  
        Grid.DataBind();  
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            grid1.DataSource = dr;
            grid1.DataBind();
        }
        con.Close();
        grid1.Visible = true;
    }
