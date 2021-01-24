        ConnectionString.OpenConnection();
        string Query = "SELECT Username FROM Users WHERE Username=@user";
        SqlCommand checkUsername = new SqlCommand(Query, ConnectionString.GetConnection());
        checkUsername.Parameters.AddWithValue("@user", uName);
        var UserExist = checkUsername.ExecuteScalar();
        if (UserExist == null)
        {
            return true;
        }
        else
        { 
            return false;
        }
    }
