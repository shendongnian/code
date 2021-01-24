    class Program
    {
        static void Main(string[] args)
        {
            var start = new DateTime(2018, 06, 01);
            var end = new DateTime(2018, 06, 30);
            var month = EachDay(start, end);
            var start1 = new DateTime(2018, 06, 04);
            var end1 = new DateTime(2018, 06, 06);
            var sub1 = EachDay(start1, end1);
            var start2 = new DateTime(2018, 06, 11);
            var end2 = new DateTime(2018, 06, 14);
            var sub2 = EachDay(start2, end2);
            var start3 = new DateTime(2018, 06, 17);
            var end3 = new DateTime(2018, 06, 20);
            var sub3 = EachDay(start3, end3);
            var withoutExcluded = month.Except(sub1).Except(sub2).Except(sub3);
            var ranges = GetRanges(withoutExcluded);
            foreach (var r in ranges)
            {
                Console.WriteLine($"range: {r.Start} {r.End}");
            }
        }
        //https://stackoverflow.com/a/1847601/3330348
        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
        public static IEnumerable<Range> GetRanges(IEnumerable<DateTime> dates)
        {
            var start = dates.First();
            var end = dates.First();
            var prev = dates.First();
            var next = DateTime.Now;
            foreach (var d in dates.Skip(1))
            {
                next = d;
                var diff = next - prev;
                if (diff.TotalDays > 1)
                {
                    yield return new Range { Start = start, End = end };
                    start = d;
                }
                prev = d;
                end = d;
            }
            yield return new Range { Start = start, End = end };
        }
        public class Range
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }
    }
