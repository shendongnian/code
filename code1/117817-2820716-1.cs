    //
    MySqlCommand myCommand = new MySqlCommand();
    myCommand.CommandType = System.Data.CommandType.StoredProcedure;
    myCommand.CommandText = "FNC_IsUserInSite";
    
    MySqlParameter rv = new MySqlParameter();
    rv.Direction = System.Data.ParameterDirection.ReturnValue;
    rv.MySqlDbType = MySqlDbType.Int32;
    rv.ParameterName = "@retval";
    myCommand.Parameters.Add(rv);
    
    myCommand.Connection = connection;
    //
    
    myCommand.ExecuteScalar();
    object ret = myCommand.Parameters["@retval"].Value;
    
    if (ret != null)
    {
        if ((int)ret > 0)
        {
           ...
        }
    }
