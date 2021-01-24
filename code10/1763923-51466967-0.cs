    public bool ProfileUser (string log)
    {
        string value = "";
        SqlCommand cmd = conn.CreateCommand ();
        cmd.CommandText = "select profile from user where user = '" + log + "';";
        SqlDataReader s = cmd.ExecuteReader ();
        if (s.Read ())
        {value = s ["profile"]. ToString (); }
        
        return value == "admin"? true:false;
    }
     bool login = ProfileUser(name.Text)
     if (login) Response.Redirect ("admin.aspx");
     else Response.Redirect ("user_c.aspx");
