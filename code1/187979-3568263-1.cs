     cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = @"SELECT ImageData, " 
                                     + " ContentType, " 
                                     + " ImageName " 
                                     + " FROM UsersImage "
                                     + " WHERE UserName = @UserName ";
    
                    cmd.Parameters.Add(new SqlParameter("@UserName", ThreadUserName));
    
    using (IDataReader reader = cmd.ExecuteReader())
    {
        if (reader.Read())
        {
            if (reader["ContentType"] != DBNull.Value)
            {
                ContentType = Convert.ToString(reader["@ContentType"]);
            }
            if (reader["ImageName"] != DBNull.Value)
            {
                ImageName = Convert.ToString(reader["@ImageName"]);
            }
            if (reader["ImageData"] != DBNull.Value)
            {
                ImageData = Convert.ToByte(reader["@ImageData"]);
            }
            int affectedRows = cmd.ExecuteNonQuery();
            if (affectedRows != 1)
            {
            }
        }
    }
