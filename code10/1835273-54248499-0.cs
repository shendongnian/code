    var query = list.GroupBy(x => x.Test)
                    .Select(x => new
                        {
                           x.Key,
                           Results = x.ChunkBy(p => p.Result)
                                      .Select(y => new { y.Key, Count = y.Count() })
                                      .Where(z => z.Count > 1)
                        });
    foreach (var item in query)
    {
       Console.WriteLine($"Group key = {item.Key}");
       foreach (var inner in item.Results.Where(x => x.Key =="Fail"))
       {
          Console.WriteLine($" - {inner.Count} consecutive fail tests or ({inner.Count}-1) = {inner.Count-1} sequential fails ");
       }
    }
