    public async Task CreateAsync(TUser user)
    {
         try
         {
             await connection.ExecuteAsync("CreateUser", param, commandType: CommandType.StoredProcedure);
         }
         catch(SqlException sqlEx)
         {
             // log error here
         }
    }
