    public static DateTime NearestQuarterEnd(this DateTime date) {
        IEnumerable<DateTime> candidates = 
            QuartersInYear(date.Year).Union(QuartersInYear(date.Year - 1));
        return candidates.Where(d => d <= date).OrderBy(d => d).Last();
    }
    static IEnumerable<DateTime> QuartersInYear(int year) {
        return new List<DateTime>() {
            new DateTime(year, 3, 31),
            new DateTime(year, 6, 30),
            new DateTime(year, 9, 30),
            new DateTime(year, 12, 31),
        };
    }
