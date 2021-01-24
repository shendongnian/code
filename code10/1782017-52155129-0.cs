    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string CodeReg = txtCodeReg.Text;
    
        Guid g = new Guid();
    
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source=.;Initial Catalog=Db_Hospital;Integrated Security=True";
    
        con.Open();
    
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "Select CodeMeli From Tbl_Staff where (CONVERT(VARCHAR(36),ID)=@ID)";
        cmd.Parameters.AddWithValue("@ID", txtCode.Text);
    
        SqlDataReader r = cmd.ExecuteReader();
        r.Read();
    
        if (r.HasRows)
        {
            Session["SID"] = g;
        }
    }
