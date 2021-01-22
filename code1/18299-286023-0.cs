    public bool LoginUser(String username, String password)
    { 
        bool r = false;
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString))
        {
            using(SqlCommand cm = new SqlCommand())
            {
                cm.Connection = cn;
                cm.CommandType = CommandType.Text;
                cm.CommandText = "SELECT Name, SalesNumber FROM users WHERE uname = @username AND pwd = @password;";
                cm.Parameters.AddWithValue("@username", username);
                cm.Parameters.AddWithValue("@password", password);
                
                cn.Open();
                SqlDataReader dr = cm.ExecuteReader();
    
                if (dr.HasRows)
                {
                    // user exists
                    HttpContext.Current.Session["SalesNumber"] = dr["SalesNumber"].ToString();
                    HttpContext.Current.Session["Username"] = username;
                    HttpContext.Current.Session["Name"] = dr["Name"].ToString();
    
                    r = true;
                }
                else
                { 
                    // Clear all sessions
                    HttpContext.Current.Session["SalesNumber"] = "";
                    HttpContext.Current.Session["Username"] = "";
                    HttpContext.Current.Session["Name"] = "";
                }
            }
        }
        return r;
    }
