    var TheList = (from t in MyDataContext.TheTable
                   where t.SomeDate > DateTime.UtcNow.AddMonths(-3)
                   orderby g.SomeDate descending
                   select new SomeObject()
                   {
                         TheUserID = g.UserID,
                    })
                    .GroupBy(x => x.TheUserID)
                    .Select(x => x.FirstOrDefault())
                    .ToList();  
