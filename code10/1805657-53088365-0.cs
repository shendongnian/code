    public IEnumerable<ChangeLog> GetChangeLogWithFilter(ChangeLogRequest request)
    {
       var query = dbContext.ChangeLogs;
       if(!string.IsNullOrEmpty(request.UserName))
       {
          query = query.Where(x => x.UserName.Equals(request.UserName));
       }
       // then you repeat the above with the rest of the values if they are available
       return query.ToList();
    }
