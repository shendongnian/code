    static void Main()
    {
        foreach (var x in FiscalYears(new DateRange[] { 
            new DateRange { Begin = new DateTime(2001, 1, 1),
                            End = new DateTime(2001, 8, 14) },
            new DateRange { Begin = new DateTime(2001, 8, 15),
                            End = new DateTime(2002, 7, 10) } }))
        {
            Console.WriteLine("from {0:yyyy MMM dd} to {1:yyyy MMM dd}",
                              x.Range.Begin, x.Range.End);
            foreach (var p in x.Periods)
                Console.WriteLine(
                "    period: {0:yyyy MMM dd} to {1:yyyy MMM dd}", p.Begin, p.End);
        }
    }
