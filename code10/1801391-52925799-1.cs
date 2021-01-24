    var query = (from o in db.Set<Order>()
                 from lastStatus in db.Set<OrderStatus>()
                     .Where(s => o.Id == s.OrderId)
                     .OrderByDescending(s => s.CreatedDate)
                     .Take(1)
                 where lastStatus.Id != 1
                 select new { o.Name, StatusId = lastStatus.Id }
                ).ToList();
