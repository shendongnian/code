     int N = 4; // Number of desired elements with value
     var backupList = Simulation.ConvertAll(x => new TeamClass
     {
         Country = x.Country,
         CountryCode = x.CountryCode,
         Points = new List<double>(x.Points.Take(N).Concat(x.Points.Skip(N).ToList().ConvertAll(p => new double())));
     })
     .OrderByDescending(o => o.Points.Sum())
     .ToList();
