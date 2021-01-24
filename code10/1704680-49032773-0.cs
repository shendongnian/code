               string input = "2018-02-28 10:00:00,A1, A2\n" +
                              "2018-02-28 10:05:00,A3, A4\n" +
                              "2018-02-28 10:10:00,A5, A6\n" +
                              "2018-02-28 10:00:00,A7, A8";
               DateTime now = DateTime.Now;
               var results = input.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(x => x.Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries))
                   .Select( y => new { date = DateTime.Parse(y.First()), colA = y.Skip(1).First(), colB = y.Last() })
                   .Where(x => x.date <= now).ToList();
