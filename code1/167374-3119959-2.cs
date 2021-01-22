    var results = 
        dbo.IO_Times
            .OrderByDescending(i => SqlMethods.DateDiffMinutes(i.TimeIn, i.TimeOut))
            .GroupBy(i => i.IDNum)
            .Select(g => new 
                { 
                    ID = g.Key, 
                    Time = g.Max(t => t.TimeOut - t.TimeIn)
                });
                             
