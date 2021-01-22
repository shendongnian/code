    static void Main()
    {
        foreach (var x in FiscalYears(new DateRange[] { 
            new DateRange { Begin = new DateTime(2001, 1, 1),
                            End = new DateTime(2001, 8, 14) },
            new DateRange { Begin = new DateTime(2001, 8, 15),
                            End = new DateTime(2002, 7, 10) } }))
            Console.WriteLine("from {0:yyyy MMM dd} to {1:yyyy MMM dd}",
                              x.Begin, x.End);
    }
