    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        MySqlConnection con = new MySqlConnection("server=localhost;User Id=root;database=result;password=1234");
        con.Open();
        
        MySqlCommand cmd = new MySqlCommand("Select * from users where username=?username and password=?password", con);
        cmd.Parameters.Add(new MySqlParameter("username", this.Login1.UserName));
        cmd.Parameters.Add(new MySqlParameter("password", this.Login1.Password)); 
        
        MySqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows ==true)
        {
            e.Authenticated = true;
        }
    }
