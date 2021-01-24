       User user = new User();
       SqlDataReader sqlDataReader = cmd.ExecuteReader();
       if(sqlDataReader.Read())
       {
           user.Id = (int)sqlDataReader["UserId"];
           user.Login = sqlDataReader["UserLogin"].ToString();
           user.PasswordHash = sqlDataReader["UserPassword"].ToString();
           user.Salt = (byte[])sqlDataReader["UserPasswordSalt"];
        }
