    var q = from s in db.Items
            join sub in (from c in db.Carts
                         where c.CartID == 1
                         group c by c.ItemID into g
                         select new
                         {
                             ItemID = g.Key,
                             Qty = g.Sum(s => s.Qty)
                             // or Qty = g.Select(s => s.Qty)
                             // and below: Qty = a.SelectMany(x => x.Qty).Sum()
                         })
                on s.ItemID equals sub.ItemID into a
            select new ItemViewModel
            {
                CategoryID = s.CategoryID,
                Description = s.Description,
                Price = s.Price,
                Qty = a.Sum(x => x.Qty),
                ItemID = s.ItemID,
                ItemName = s.ItemName
            };
