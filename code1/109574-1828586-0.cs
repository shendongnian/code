    Show(AnaList, 30000, int.MaxValue, "Top Movement");
    Show(AnaList, 10000, 30000, "Average Movement");
    Show(AnaList, 0, 10000, "Poor Movement");
    
    static void Show(IEnumerable<SalesAnalysis> data, int min, int max, string caption)
    {
        int[] years = {2008,2009};
        var qry = from row in data
                   where years.Contains(row.Year)
                    && row.NumberOfUnitsSold >= min
                    && row.NumberOfUnitsSold < max
                   orderby row.NumberOfUnitsSold descending
                   select row;
        
        Console.WriteLine(caption);
        Console.WriteLine();
        Console.WriteLine("Product\tYear\tUnits");
        foreach(var row in qry) {
            Console.WriteLine("{0}\t{1}\t{2}",
                row.ProductCode, row.Year, row.NumberOfUnitsSold);
        }
    }
