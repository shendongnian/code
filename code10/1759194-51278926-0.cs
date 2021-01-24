    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string EmailAddr = "";
        string Password = "";
        string strConn = ConfigurationManager.ConnectionStrings["EPortfolioConnectionString"].ToString();
    
        SqlConnection conn = new SqlConnection(strConn);
    
        SqlCommand cmd = new SqlCommand("SELECT * FROM Parent WHERE [EmailAddr]=@EmailAddr AND [Password]=@Password", conn);
    
        cmd.Parameters.AddWithValue("@EmailAddr", EmailAddr);
        cmd.Parameters.AddWithValue("@Password", Password);
    
        SqlDataAdapter daParentLogin = new SqlDataAdapter(cmd);
        DataSet result = new DataSet();
    
        conn.Open();
        daParentLogin.Fill(result, "Login");
        conn.Close();
    
        if (result.Tables["Login"].Rows.Count > 0)
        {
              Response.Redirect("SubmitViewingRequest.aspx");
        }
        else
        {
              lblMessage.Text = "Invalid login credentials";
        }
    }
