        public string TestLogin(string UserName, string Password, string Auth, string Domain)
        {
    	string thisLogin = "";
    	//App Pool Identity
    	if (Auth.Equals("local"))
    	{
    		using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString()))
    		{
    			SqlCommand cmd = new SqlCommand("SELECT SUSER_SNAME()", cn);
    			cn.Open();
    			SqlDataReader rdr = cmd.ExecuteReader();
    			while (rdr.Read())
    			{
    				thisLogin = rdr[0].ToString();
    			}
    			cn.Close();
    
    		}
    	}
    	
    	if(Auth.Equals("SQL"))
    	{
    		using (SqlConnection cn = new SqlConnection("Data Source = .\\D01; Initial Catalog = master; Integrated Security = false; User ID = " + UserName + "; Password=" + Password + ";"))
    		{
    			SqlCommand cmd = new SqlCommand("SELECT SUSER_SNAME()", cn);
    			cn.Open();
    			SqlDataReader rdr = cmd.ExecuteReader();
    			while(rdr.Read())
    			{
    				thisLogin = rdr[0].ToString();
    			}
    			cn.Close();
    		}
    	}
    
    	if(Auth.Equals("Remote"))
    	{
    		string login = UserName;
    		string domain = Domain;
    		string password = Password;
    
    		using (UserImpersonation user = new UserImpersonation(login, domain, password))
    		{
    			if (user.ImpersonateValidUser())
    			{
    				using (SqlConnection cn = new SqlConnection("Data Source = .\\D01; Initial Catalog = master; Integrated Security = SSPI;"))
    				{
    					SqlCommand cmd = new SqlCommand("SELECT SUSER_SNAME()", cn);
    					cn.Open();
    					SqlDataReader rdr = cmd.ExecuteReader();
    					while (rdr.Read())
    					{
    						thisLogin = rdr[0].ToString();
    					}
    					cn.Close();
    				}
    			}
    		}
    	}
    		
    	if(thisLogin.Equals(""))
    	{
    		thisLogin = "User failed";
    	}
    	return thisLogin;
        }
