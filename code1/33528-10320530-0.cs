    var total = from T1 in context.T1
                join T2 in context.T2 on T1.T2ID equals T2.T2ID
                join T3 in context.T3 on T2.T3ID equals T3.T3ID
                group T3 by new { T1.Column1, T1.Column2 } into g
                select new { 
                    Column1 = g.Key.Column1, 
                    Column2 = g.Key.Column2, 
                    Amount = g.Sum(t3 => t3.Column1) 
                };
