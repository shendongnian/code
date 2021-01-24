    var result = from a in liabilites
                 group a by a.DriverC into g			 
			     select new {
			            DriverC = g.First().DriverC,
						Description = g.First().Description,
                        Liabilities = g.Where(x=>x.LiabilitiesC==1).Sum(a=>a.Amount)??0,
                        Payment = g.Where(x=>x.LiabilitiesC==0).Sum(a=>a.Amount)??0,
                        Date = g.First().Dates,
			     };
			 
    Console.WriteLine(result);
