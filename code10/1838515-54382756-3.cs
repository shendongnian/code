    public async Task<bool> CreateAsync(TUser user)
    {
         bool result;
         try
         {
            await connection.ExecuteAsync("CreateUser", param, commandType: CommandType.StoredProcedure);
            result = true;
         }
         catch(SqlException sqlEx)
         {
             // log error here
            result = false;
         }
         return result;
    }
