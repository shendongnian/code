    var result = (from s in data
                  group s by  s.Name 
                  into grp 
                  select new {
                     name =  grp.Key,
                     score = grp.Sum(s=> s.Score),
                     avg =   decimal.Round(grp.Average(s =>Convert.ToDecimal(s.Score)),1,MidpointRounding.AwayFromZero),
                     star =  grp.Where(s=> s.Score == 5).Count()
                  }).ToList();
    Console.WriteLine(result);
     
