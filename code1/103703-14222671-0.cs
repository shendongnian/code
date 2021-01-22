    var subquery = from c in CustAccesses
                group c by c.CustID into g
                select new
                {
                    CustID = g.Key,
                    AccessDate = g.Max(a => a.AccessDate)
                };
    var query = from c in CustAccesses
                join s in subquery 
                  on c.CustID equals s.CustID
                where c.AccessDate == s.AccessDate
                 && !string.IsNullOrEmpty(c.AccessReason)
                select c;
