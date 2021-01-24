    public static readonly List<Interval<int>> range = new List<Interval<int>>
            {
                    new Interval<int>(1, 0, 1),
                    new Interval<int>(2, 1, 2),
                    new Interval<int>(3, 2, 4),
                    new Interval<int>(4, 4, 6),
                    new Interval<int>(5, 6, 9),
                    new Interval<int>(6, 9, 12),
                    new Interval<int>(7, 12, 15),
                    new Interval<int>(8, 15, 18),
                    new Interval<int>(9, 18, 24),
                    new Interval<int>(10, 24, 30),
                    new Interval<int>(11, 30, 36),
                    new Interval<int>(12, 36, 48),
                    new Interval<int>(13, 48, 60),
                    new Interval<int>(14, 60, int.MaxValue)
            };
    
    var months = 5;
    var visit = range.Where(x => x.InRange(months)).Select(x => x.Visit).FirstOrDefault();
