    SqlDataReader reader = new  SqlDataReader();
    UsersEnt user = null; 
 
    using (ConnectionManager cm = new ConnectionManager()) 
    { 
        SqlParameter[] parameters = new SqlParameter[1]; 
 
        parameters[0] = new SqlParameter("@Email", email); 
 
        try 
        { 
            reader = SQLHelper.ExecuteReader(cm.Connection, 
                    "sp_LoadUserInfo", parameters); 
            if (reader.Read()) 
                 user = new UsersDF(reader); 
        } 
        catch (SqlException ex) 
        { 
            user.Exception=ex.Message;        
        } 
 
    } 
 
    return user; 
