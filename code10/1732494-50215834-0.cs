    public void referFriend(string username)
    {
      
     ...
       comm.Parameters.Add("@DRA_NOMBRE_CLIENTE", System.Data.SqlDbType.VarChar).Value = username;
     ...
              
