    public static void TEST()
    {
        // creating list of some random dates
        Random rnd = new Random();
        List<DateTime> lstDte = new List<DateTime>();
        while (lstDte.Count < 100)
        {
            lstDte.Add(DateTime.Now.AddDays((int)(Math.Round((rnd.NextDouble() - 0.5) * 100))));
        }
        // grouping 
        var weeksgrouped = lstDte.GroupBy(x => (DateTime.MaxValue - x).Days / 7);
    }
