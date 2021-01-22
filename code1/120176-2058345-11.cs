    static Dictionary<int, DateTime[]> cache = new Dictionary<int, DateTime[]>();
    public static DateTime[] StartOfQuarters(DateTime date) {
        int year = date.Year;
        DateTime[] startOfQuarters;
        if(!cache.TryGetValue(year, out startOfQuarters)) {
            startOfQuarters = new[] {
                new DateTime(year, 1, 1),
                new DateTime(year, 4, 1),
                new DateTime(year, 7, 1),
                new DateTime(year, 10, 1)
            };
            cache.Add(year, startOfQuarters);
        }
        return startOfQuarters;
    }
