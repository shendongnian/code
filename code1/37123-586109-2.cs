    using(var ctx = new DataClasses2DataContext())
    {
        ctx.Log = Console.Out;
        int? mgr = (int?)null; // redundant int? for comparison...
        // 23 rows:
        var bosses1 = ctx.Employees.Where(x => x.ReportsTo == (int?)null).ToList();
        // 0 rows:
        var bosses2 = ctx.Employees.Where(x => x.ReportsTo == mgr).ToList();
    }
