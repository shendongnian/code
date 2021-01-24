        var result = db.Items.GroupJoin(db.Carts.Where(x => x.CartID == 1), item => item.ItemID, cart => cart.ItemID, 
                     (item, cart) => new { item, cart })
                    .SelectMany(x => x.cart.DefaultIfEmpty(), (it, ca) =>
                    {
                        return new ItemViewModel
                    {
                            ItemName = it.item.ItemName,
                            Price = it.item.Price,
                            ItemID = it.item.ItemID,
                            // ... .... .... 
                            // Fill the required columns from it.Item property..
                            Qty = ca != null ? ca.Qty : 0
                        };
                    }).ToList();
    
