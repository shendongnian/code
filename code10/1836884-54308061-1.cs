	var itemsValidity = 
   		products.GroupBy(p => p.ItemId).
                 Select(g => new
			     {
                     ItemId = g.Key,
                     IsValid = !g.GroupBy(item => item.ItemCode).Skip(1).Any()
                 });
