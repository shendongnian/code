    public async Task<bool> CreateAsync(TUser user)
    {
         bool result;
         try
         {
            result = (bool)(await connection.ExecuteAsync("CreateUser", param, commandType: CommandType.StoredProcedure));
         }
         catch(SqlException sqlEx)
         {
             // log error here
             // update result's value
         }
         return result;
    }
