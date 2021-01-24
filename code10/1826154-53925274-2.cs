    using (var session = sessionFactory.OpenSession())
    {
        // Enable filter and pass parameters
        var startMonthsValue = 2000 * 12 + 1;    // january 2000
        var endMonthsValue = 2010 * 12 + 3;  // march 2010
        session.EnableFilter("MonthsFilter")
            .SetParameter("startMonths", startMonthsValue)
            .SetParameter("endMonths", endMonthsValue);
        // Create and execute query (no filter for B needed here)
        var list = session.QueryOver<A>()
            .Where(x => x.Active)
            .List();
        // Do whatever you want with the results
        foreach (var item in list)
        {
            Console.WriteLine("A id: {0} - B children count: {1}", item.Id, item.BList.Count());
        }
    }
