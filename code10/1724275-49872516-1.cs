    if(reader.Read())
    {
        u = new User(reader["username"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["role"].ToString());
    }
    else
    {
       u = null;
    }
    if(reader.Read())
    {
        // bug detected, two user with same name and password, log this/throw an exception
    }
