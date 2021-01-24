    public async Task<ActivityHeader> GetAllActivityHeader(CancellationToken cancellationToken)
    {
          ....
          if (conn.State == ConnectionState.Closed)
               await conn.OpenAsync(cancellationToken);
		  var activityHeaderTask = conn.QueryAsync<ActivityHeader>("GetActivityHeader", cancellationToken);
	      var result = await activityHeaderTask.AsList()
             
          return result;
    }
