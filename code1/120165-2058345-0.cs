    static DateTime GetNextProcessingDate(
        DateTime itemCompletedDate,
        int monthWithinQuarter,
        int weekWithinMonth
    ) {
            if (monthWithinQuarter < 1 || monthWithinQuarter > 3) {
                throw new ArgumentOutOfRangeException("monthWithinQuarter");
            }
            int year = itemCompletedDate.Year;
            DateTime[] startOfQuarters = new[] {
                new DateTime(year, 1, 1),
                new DateTime(year, 4, 1),
                new DateTime(year, 7, 1),
                new DateTime(year, 10, 1)
            };
            DateTime startOfQuarter = startOfQuarters.Where(d => d <= itemCompletedDate)
                                                     .OrderBy(d => d)
                                                     .Last();
            int month = startOfQuarter.Month + monthWithinQuarter - 1;
            DateTime candidate = new DateTime(year, month, 1);
            if (candidate < itemCompletedDate) {
                month += 3;
            }
            int day = (weekWithinMonth - 1) * 7 + 1;
            if (day > DateTime.DaysInMonth(year, month)) {
                throw new ArgumentOutOfRangeException("weekWithinMonth");
            }
            return new DateTime(year, month, day);
        }
