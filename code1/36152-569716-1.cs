        using(var ctx = new DataClasses1DataContext())
        {
            ctx.Log = Console.Out;
            Expression<Func<Customer, bool>> lhs =
                x => x.Country == "UK";
            Expression<Func<Customer, bool>> rhs =
                x => x.ContactName.StartsWith("A");
            var arr1 = ctx.Customers.Where(
                lhs.OrElse(rhs)).ToArray();
            var arr2 = ctx.Customers.Where(lhs)
                .Union(ctx.Customers.Where(rhs)).ToArray();
        }
