    public int Login(string connectionString,string username,string password)
    {
        int result = 0; //Default result value.
    
        SqlConnection con=new SqlConnection(connectionString);
        con.Open();
    
        SqlCommand validUser = new SqlCommand("SELECT count(*) from USER where username=@username", con);
        validUser.Parameters.AddWithValue("@username", username);
        int value=Convert.ToInt32(validUser.ExecuteScalar().ToString());
        if (value == 1)
        {
            //check for password
            SqlCommand validPassword = new SqlCommand("SELECT password from USER where username=@username", con);
            validPassword.Parameters.AddWithValue("@username", username);
            string pass = validPassword.ExecuteScalar().ToString();
            if (pass == password)
            {
                //valid login
                result = 1;
            }
            else
            {
                result = 0;
            }
        }
        else if (value == 0)
        {
            result = 2;
    
        }
    
        return result;
    }
