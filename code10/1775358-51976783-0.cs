    const int pageSize = 1000;
    var count = context.ChangeTracker.Entries()
        .Count(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted);
    
    var pages = (int) Math.Ceiling((double) count / PageSize);
    int loopCounter = 0;
    while (loopCounter < pages)
    {
       var changes = context.ChangeTracker.Entries()
          .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted)
          .Select(x => new { Type = x.Entity.GetType(), State = x.State.ToString(), Original = x.OriginalValues.ToObject(), Updated = x.CurrentValues.ToObject() })
          .Skip(loopCounter * pageSize)
          .Take(pageSize);
    
       var data = new
       {
          PageNumber = loopCounter,
          Changes = changes,
       };
    
       string changeData = JsonConvert.SerializeObject(data, Formatting.Indented);
       // Fire across to destination to be processed. Be sure to send the total # of pages because the server cannot start processing these unless they are in order.
