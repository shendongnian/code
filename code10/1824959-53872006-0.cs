        public class Order
        {
            public int OrderId { get; set; }
        
            public int UserId { get; set; }
        
            public DateTime Date { get; set; }
        
            public string ItemName { get; set; }
        }
        
        table.Where(o => o.Date < DateTime.UtcNow.AddMonths(-3))
                        .GroupBy(o => o.UserId)
                        .Select(g => new { UserId = g.Key, LastOrder = g.OrderByDescending(o => o.Date).FirstOrDefault() })
    .ToList();
