    using System.Data.Objects.SqlClient;
    
    var codes = (from c in _twsEntities.PromoHistory
                             where (c.UserId == userId)
                             group c by SqlFunctions.DatePart("wk", c.DateAdded) into g
                             let MaxDate = g.Max(c => SqlFunctions.DatePart("wk",c.DateAdded))
                             let Count = g.Count()
                             orderby MaxDate
                             select new { g.Key, MaxDate, Count }).ToList();
