    var clientFirstOrders = db.Customers.Where(c => c.IsNew)
        .Select(c => new{
            Customer = c, 
            FirstOrder = c.Orders.OrderBy(c => c.OrderDate).FirstOrDefault()
        })
        // might have to do (int?)FirstOrder.Id != null or something like that.
        .Where(e => e.FirstOrder != null);
