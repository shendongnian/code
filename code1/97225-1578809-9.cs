    using(var ctx = new MyDataContext()) {
        var qry = from cust in ctx.Customers
                  where cust.Region == "North"
                  select new { cust.Id, cust.Name };
        foreach(var row in qry) {
            Console.WriteLine("{0}: {1}", row.Id, row.Name);
        }
    }
