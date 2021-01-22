    // When the registration form is submitted
    protected void regSubmit(object sender, EventArgs e)
    {
        // Verify that username is unique
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblUsers WHERE username = @UserName", cn))
        {
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = txtUserName.Text;
            cn.Open();
            int result = (int)cmd.ExecuteScalar(); 
        }
        statusLabel.Text = txtUserName.Text;
    }
