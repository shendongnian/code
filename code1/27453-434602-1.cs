        using(var ctx = new MyDataContext(CONN))
        {
            ctx.Log = Console.Out;
            int frCount = ctx.Get<Customer>(c => c.Country == "France").Count();
        }
