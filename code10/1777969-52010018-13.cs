    var query = _context.Benchmark.GroupBy(x => x.Device, 
                  (key, group) => new  //Result selector
                  {
                      Device = key,
                      Count = group.Count()//Avoid to use Count
                  });
    await query.ToListAsync();
