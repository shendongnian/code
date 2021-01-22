     try
     {
         using(SqlDataReader dataReader = _getMaxTimeCommand.ExecuteReader())
         {
             dataReader.Read();
             _currentTick = dataReader.GetInt32(0);
         }
     }
     catch (Exception ex)
     {
        //Log the error
     }
