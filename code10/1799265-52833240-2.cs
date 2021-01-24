    class Program
    {
        static void Main(string[] args)
        {           
            var results = (from o in MyList
                           group o by new { o.Organization } into g
                           select new
                           {
                               Org_Id = g.Key.Organization,
                               Year = g.Select(x => x.Year)
                                       .Max(),
                               Month = g.Where(x => x.Year == g.Select(y => y.Year).Max())
                                        .Select(z => z.Month)
                                        .Max(),
                               Sum = g.Where(x => x.Month == g.Where(y => y.Year == g.Select(z => z.Year).Max())
                                                              .Select(y => y.Month)
                                                              .Max())
                                      .Select(z => z.Value)
                                      .Sum()
                           }).ToList();
            results.ForEach(x => Console.WriteLine($"Org_Id: {x.Org_Id} \t Year: {x.Year} \t Month: {x.Month} \t Sum: {x.Sum}"));
            Console.ReadLine();
        }
    }
