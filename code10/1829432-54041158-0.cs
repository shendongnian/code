    var castedItems = missingItems.ToList();
    var offset = 0;
    var limit = 0;
      while (castedItems.Any())
      {
        var subList = castedItems.Take(2500).ToList();
    limit = limit + 2500;
        DBRetry.Do(() => EFBatchOperation.For(ctx, 
        ctx.SearchedUserItems).InsertAll(subList), TimeSpan.FromSeconds(2));
        castedItems.RemoveRange(offset, limit);
    offset = offset + limit?           
      }
