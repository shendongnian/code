    public static DateTime calcMondayDate(DateTime input) {
        int delta = (DayOfWeek.Monday - input.DayOfWeek - 7) % 7;
        DateTime monday = input.AddDays(delta);
        return monday;
    }
