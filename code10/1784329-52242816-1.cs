    using(var ctx = new MyContext)
    {
        var ord = new Order{ Id = 1, Customer = new Customer {Id = 10}};
        ctx.Orders.Add(ord);
        ctx.SaveChanges();  
    }
