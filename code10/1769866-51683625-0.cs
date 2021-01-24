    protected void Button1_Click(object sender, EventArgs e)
    {
        string Cs = ConfigurationManager.ConnectionStrings["MyDatabase1ConnectionString"].ConnectionString;
        
        // set up query - using PARAMETERS as you always should!
    	// Also: you don't seem to need the *whole* row - all the columns of "Users" - so select just what you **really need**!
        string query = "Select UserId from Users where username = @username and password = @password;";
    
    	// put both SqlConnection *AND* SqlCommand into "using" blocks
        using (SqlConnection con=new SqlConnection(Cs))
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            // provide the parameters
    		cmd.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = Username.Text;
    		cmd.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = Password.Text;
    		
    		// use an ExecuteScalar call to get the UserId from Users - and check if it exists
    		con.Open();
    
    		object result = cmd.ExecuteScalar();
    
    	    // if we get something back --> the user with this password exists --> redirect
            if (result != null)
            {
                Response.Redirect("~/Cuhome.aspx");
            }
            else
            {
                LblError.Text = "Invalid Username & Password";
            }
        }
    }
