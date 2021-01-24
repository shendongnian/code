    public static class DateOperations
    {
        public static List<DateTime> GetDates(this List<string> dateStrings)
        {
            List<DateTime> asDates = new List<DateTime>();
            dateStrings.ForEach(e =>
            asDates.Add(DateTime.ParseExact(e, "yyyyMM", CultureInfo.InvariantCulture, DateTimeStyles.None))
            );
            return asDates;
        }
    }
