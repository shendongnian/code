        using(var ctx = new DataClasses1DataContext())
        {
            ctx.Log = Console.Out; // log TSQL to console
            var qry = from cust in ctx.Customers
                      where cust.CustomerID != ""
                      group cust by cust.Country
                      into grp
                      select new
                      {
                          Country = grp.Key,
                          Count = grp.Select(x => x.City).Distinct().Count()
                      };
            
            foreach(var row in qry.OrderBy(x=>x.Country))
            {
                Console.WriteLine("{0}: {1}", row.Country, row.Count);
            }
        }
