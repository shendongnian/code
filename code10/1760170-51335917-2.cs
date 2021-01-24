     public static async Task<dynamic> GetInternalAsync()
     {
      if (InternalToken == null || InternalToken.ExpiresAt < 
       DateTime.UtcNow)
      {
        InternalToken = await Get2LeggedTokenAsync(new Scope[] { 
           Scope.BucketCreate, Scope.BucketRead, Scope.DataRead, 
           Scope.DataCreate,Scope.BucketDelete,Scope.DataWrite});
            InternalToken.ExpiresAt = 
        DateTime.UtcNow.AddSeconds(InternalToken.expires_in);
      }
      return InternalToken;
    }
