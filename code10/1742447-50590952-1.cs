    var result= (from A in ListA
                 join B in List B
                 on A.ID equals B.ID
                 select new {A,B})
                 .GroupBy(x=>x.A.Id)
                 .Select(x=>new
                  {
                    ID=x.Key
                    count=x.Count(),
                    AName=x.Select(z=>z.A.AName)
                  }).ToList();
