    using (DataClasses1DataContext ctx = new DataClasses1DataContext())
    {
        var qry = from order in ctx.Orders
                  where order.ShipCountry == Foo.Bar.MyEnum.Brazil
                    || order.ShipCountry == Foo.Bar.MyEnum.Belgium
                  select order;
        foreach (var order in qry.Take(10))
        {
            Console.WriteLine("{0}, {1}", order.OrderID, order.ShipCountry);
        }
    }
