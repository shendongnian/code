    class Program
    {
        static void Main(string[] args)
        {
            List<Org> MyList = new List<Org>();
            MyList.Add(new Org { Organization = 01, State = "NY", Year = 2017, Month = 1, Value = 1 });
            MyList.Add(new Org { Organization = 01, State = "WA", Year = 2017, Month = 1, Value = 2 });
            MyList.Add(new Org { Organization = 01, State = "SA", Year = 2017, Month = 1, Value = 3 });
            MyList.Add(new Org { Organization = 01, State = "NY", Year = 2017, Month = 2, Value = 4 });
            MyList.Add(new Org { Organization = 01, State = "WA", Year = 2017, Month = 2, Value = 5 });
            MyList.Add(new Org { Organization = 01, State = "SA", Year = 2017, Month = 2, Value = 6 });
            MyList.Add(new Org { Organization = 02, State = "NY", Year = 2015, Month = 9, Value = 7 });
            MyList.Add(new Org { Organization = 02, State = "WA", Year = 2015, Month = 9, Value = 8 });
            MyList.Add(new Org { Organization = 02, State = "SA", Year = 2015, Month = 9, Value = 9 });
            MyList.Add(new Org { Organization = 02, State = "NY", Year = 2016, Month = 1, Value = 10 });
            MyList.Add(new Org { Organization = 02, State = "WA", Year = 2016, Month = 1, Value = 11 });
            MyList.Add(new Org { Organization = 02, State = "SA", Year = 2016, Month = 1, Value = 12 });
            MyList.Add(new Org { Organization = 03, State = "NY", Year = 2017, Month = 8, Value = 13 });
            MyList.Add(new Org { Organization = 03, State = "WA", Year = 2017, Month = 8, Value = 14 });
            MyList.Add(new Org { Organization = 03, State = "SA", Year = 2017, Month = 8, Value = 15 });
            var results = (from o in MyList
                           group o by new { o.Organization } into g
                           select new
                           {
                               Org_Id = g.Key.Organization,
                               Year = g.Select(x => x.Year).Max(),
                               Month = g.Where(x => x.Year == g.Select(y => y.Year).Max()).Select(z => z.Month).Max(),
                               Sum = g.Where(x => x.Month == g.Where(y => y.Year == g.Select(z => z.Year).Max()).Select(y => y.Month).Max()).Select(z => z.Value).Sum()
                           }).ToList();
            results.ForEach(x => Console.WriteLine($"Org_Id: {x.Org_Id} \t Year: {x.Year} \t Month: {x.Month} \t Sum: {x.Sum}"));
            Console.ReadLine();
        }
    }
