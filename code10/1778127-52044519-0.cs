    {
    string connectionString = "Data Source=###;Initial Catalog=###;Integrated Security=True";
            if (!Page.IsPostBack)                
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(UserID) from Info WHERE UserID like @UserID", sqlConnection))
                    {
                        string UserID = HttpContext.Current.Request.LogonUserIdentity.Name.Substring(4);                        
                        sqlCommand.Parameters.AddWithValue("@UserID", UserID);
                        int userCount = (int)sqlCommand.ExecuteScalar();
                        if (userCount == 0)
                        {
                            Server.Transfer("ErrorPage.aspx");
                        }
                        SQLCmd = SqlDataSource1.SelectCommand;
                        GridView1.DataBind();
                    }
                }
            }
