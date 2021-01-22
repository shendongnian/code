    var list = new List<Range>
               {
                   new Range { TypeID = 1, Date = new DateTime(2010, 2, 1) },
                   new Range { TypeID = 1, Date = new DateTime(2010, 2, 2) },
                   new Range { TypeID = 1, Date = new DateTime(2010, 2, 3) },
                   new Range { TypeID = 2, Date = new DateTime(2010, 2, 3) },
                   new Range { TypeID = 2, Date = new DateTime(2010, 2, 4) },
                   new Range { TypeID = 2, Date = new DateTime(2010, 2, 6) }
               };
               
    var filtered = list
        .Lookback((a, b) => ((b.Date - a.Date).Days <= 1 && a.TypeID == b.TypeID)
                                ? new { TypeID = a.TypeID, Diff = (b.Date - a.Date).Days, Start = a.Date, End = b.Date }
                                : null)
        .Where(a => (a != null))
        .GroupBy(a => a.TypeID + "_" + a.Diff)
        .Select(g => new { TypeID = g.Min(a => a.TypeID), Start = g.Min(a => a.Start), End = g.Max(a => a.End) });
        
