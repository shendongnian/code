                    //Solution:1 - step by step
                    //Step 1.1 > Create iQueryable view to get desired fields to make it virutal/logical table!
                    //It is inline query and it is not executed here until you call ToList at below. So it is just like SQL CTE
                    var query1 = (from i in db.tbl51567840
                                select new { Month = i.BookingDate.Value.Month, Price = i.Price.Value });
    
                    //Step 1.2 > Apply conditions and other logic to get desired result
                    var result = (from l in query1
                                  where l.Month < DateTime.Now.Month
                                  group l by l.Month into g
                                  select new { Month = g.Key, Total = g.Sum(s => s.Price) }).ToList();
    
    
                    //Solution:2 Result in one linq query
    
                    var query2 = (from i in db.tbl51567840
                                   where i.BookingDate.Value.Month < DateTime.Now.Month
                                   group i by i.BookingDate.Value.Month into g
                                   select new { Month = g.Key, Total = g.Sum(s => s.Price) }).ToList();
