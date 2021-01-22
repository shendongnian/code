    public int Login(string connectionString,string username,string password)
    {
        SqlConnection con=new SqlConnection(connectionString);
        con.Open();
    
        SqlCommand validUser = new SqlCommand("SELECT count(*) from USER where username=@username", con);
        validUser.Parameters.AddWithValue("@username", username);
        int value=Convert.ToInt32(validUser.ExecuteScalar().ToString());
        switch (value)
        {
            case 0:
                return 2;
            case 1:
                //check for password
                SqlCommand validPassword = new SqlCommand("SELECT password from USER where username=@username", con);
                validPassword.Parameters.AddWithValue("@username", username);
                string pass = validPassword.ExecuteScalar().ToString();
                return (pass == password ? 1 : 0);
            default:
                return 4; //???????
        }
    }
