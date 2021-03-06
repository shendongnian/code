    var query = _context.Benchmark.GroupBy(x => x.Device, 
                  (key, group) => new  //Result selector
                  {
                      Device = key,
                      Count = group.Select(g => g.Id)//Avoid to use Count
                  });
    await query.ToListAsync();
