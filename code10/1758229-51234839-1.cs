    _dbContext.ServiceCarriers
    .Where(sc => carriers.Any(c => c.CarrierId == sc.CarrierId))
    .GroupBy(scg => scg.Service)
    .Where(sc1 => sc1.Count() == _dbContext.ServiceCarriers
                                 .Where(scc => carriers.Any(c => 
                                              c.CarrierId == scc.CarrierId))
                                 .Select(t => t.CarrierId)
                                 .Distinct()
                                 .Count()
    ).Select(sr => sr.Key)
     .ToList();
