        static void Main(string[] args)
        {
            var dates = new List<string>()
            {
                "03-23",
                "01-21",
                "04-23",
                "06-31",
                "08-28",
                "09-04",
                "09-29",
                "09-21",
                "09-03",
                "09-01",
                "09-18"
            };
            var list = new FancyDateList(dates).GetListForDisplay();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
       }
