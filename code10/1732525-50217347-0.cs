    IQueryable<Order> orders = GetAllEntities().Include(x => x.Contact.User);
    // or var orders = GetAllEntities().Include(x => x.Contact.User).AsQueryable();
    if (includeProducts)
    {
        orders = orders.Include(x => x.ProductOrders).ThenInclude(y => y.RentStockOrders);
        orders = orders.Include(x => x.ProductOrders).ThenInclude(y => y.Product);
        orders = orders.Include(x => x.ProductOrders).ThenInclude(y => y.Currency);
        orders = orders.Include(x => x.ProductOrders).ThenInclude(y => y.Coupons);
        orders = orders.Include(x => x.AdditionalCosts);
        orders = orders.Include(x => x.Partner);
        orders = orders.Include(x => x.OrderCoupons).ThenInclude(y => y.Coupon.Partner);
        if (includeStock)
        {
            orders = orders.Include(x => x.ProductOrders).ThenInclude(y => y.RentStockOrders).ThenInclude(z => z.Stock);
        }
    }
    if (includeInvoices)
    {
        orders = orders.Include(x => x.Invoices).ThenInclude(y => y.Attachments);
    }
