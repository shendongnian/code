    var user = Membership.GetUser();
    var userId = user.ProviderUserKey;
    
    MembershipPasswordFormat passwordFormat;
    string passwordSalt;
    string password;
    
    var cstring = WebConfigurationManager.ConnectionStrings["localSqlServer"];
    using (var conn = new SqlConnection(cstring.ConnectionString))
    {
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "select PasswordFormat,PasswordSalt,Password from aspnet_Membership where UserId=@UserId";
            cmd.Parameters.AddWithValue("@UserId", userId);
            conn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                if (rdr != null && rdr.Read())
                {
                    passwordFormat = (MembershipPasswordFormat) rdr.GetInt32(0);
                    passwordSalt = rdr.GetString(1);
                    password = rdr.GetString(2);
                }
                else
                {
                    throw new Exception("An unhandled exception of type 'DoesntWorkException' has occured");
                }
            }
        }
    }
    
    //do something interesting hew with passwordFormat, passwordSalt , password 
