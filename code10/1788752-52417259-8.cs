    static class FigureDate {
        private static readonly int[] _leapYearDaysPerMonth = new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private static readonly int[] _normalYearDaysPerMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private const int YearZero = 1900;
        //Sunday is zero in DayOfWeek
        private readonly static DayOfWeek _day0 = new DateTime(YearZero, 1, 1).DayOfWeek;
    }
