            var list2 = list.Select(c => new  // 1
            {
                client = c,
                orders = c.Orders.Where(x => x.Cost > 100)
            })
            .Where(a => a.orders.Any());  //2
