    using(var ctx = new MyDataContext()) {
        ctx.Log = Console.Out;
        var rows = ctx.Orders.OrderBy(order => order.Customer,
            customer => customer.CompanyName).Take(20).ToArray();
    }
