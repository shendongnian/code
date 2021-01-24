    var itemsValidity = 
        products.GroupBy(p => p.ItemId).
                 Select(g => 
                 {
                     ItemId = g.Key,
                     IsValid = g.GroupBy(item => item.ItemCode).Skip().Any()
                 })
