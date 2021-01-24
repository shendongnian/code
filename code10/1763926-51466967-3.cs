    public bool ProfileUser(string log)
    {
        string value = string.Empty;
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = string.Format("select profile from user where user='{0}'", log);
        SqlDataReader s = cmd.ExecuteReader();
        if (s.Read()) value = s["profile"].ToString();
        
        return value == "admin";
    }
