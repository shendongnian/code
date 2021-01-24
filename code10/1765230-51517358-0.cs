    public static class DoubleExtensions
    {
        public static DateTime JulianDateToUtc(this double julianDate)
        {
            var sinceEpoch = julianDate - 2440587.500000D;
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddDays(sinceEpoch);
        }
    }
