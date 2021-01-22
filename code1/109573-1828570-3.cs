    var query = from sa in AnaList
                where sa.Year == 2008 || sa.Year == 2009
                group sa by MovementForAnalysis(sa);
    foreach (var group in query)
    {
        Console.WriteLine("{0}: ", group.Key);
        foreach (var item in group)
        {
            Console.WriteLine("{0} / {1} / {2}", item.ProductCode, 
                              item.Year, item.NumberOfUnitsSold);
        }
        Console.WriteLine();
    }
