            DateTime[] dateTimes = new[]
                                       {
                                           new DateTime(2010, 8, 24, 0, 5, 0),
                                           new DateTime(2010, 8, 24, 0, 10, 0),
                                           new DateTime(2010, 8, 24, 0, 15, 0),
                                           new DateTime(2010, 8, 24, 0, 20, 0),
                                           new DateTime(2010, 8, 24, 0, 25, 0),
                                           new DateTime(2010, 8, 24, 0, 30, 0)
                                       };
            TimeSpan interval = new TimeSpan(0, 15, 0);     // 15 minutes.
            var groupedTimes = from dt in dateTimes
                               group dt by dt.Ticks/interval.Ticks
                               into g
                               select new {Begin = new DateTime(g.Key*interval.Ticks), Values = g.ToList()};
            foreach (var value in groupedTimes)
            {
                Console.WriteLine(value.Begin);
                Console.WriteLine("\t{0}", String.Join(", ", value.Values));
            }
