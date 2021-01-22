    public class Site
    {
        static void Main()
        {
            List<Site> sites = new List<Site>()
            {
                new Site() { SiteID = 1, VisitorType = 1, Last30 = 10, Total = 100, },
                new Site() { SiteID = 1, VisitorType = 2, Last30 = 40, Total = 140, },
                new Site() { SiteID = 2, VisitorType = 1, Last30 = 20, Total = 180, },
            };
            var totals =
                from s in sites
                group s by s.SiteID into grouped
                select new
                {
                    SiteID = grouped.Key,
                    Last30Sum = 
                        (from value in grouped
                         select value.Last30).Sum(),
                };
            foreach (var total in totals)
            {
                Console.WriteLine("Site: {0}, Last30Sum: {1}", total.SiteID, total.Last30Sum);
            }
        }
        public int SiteID { get; set; }
        public int VisitorType { get; set; }
        public int Last30 { get; set; }
        public int Total { get; set; }
    }
