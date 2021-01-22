    public enum DateTimePart { Years, Months, Days, Hours, Minutes, Seconds };
    public DateTime ChangeDateTimePart(DateTime dt, DateTimePart part, int newValue)
    {
        return new DateTime(
            part == DateTimePart.Years ? newValue : dt.Year,
            part == DateTimePart.Months ? newValue : dt.Month,
            part == DateTimePart.Days ? newValue : dt.Day,
            part == DateTimePart.Hours ? newValue : dt.Hour,
            part == DateTimePart.Minutes ? newValue : dt.Minute,
            part == DateTimePart.Seconds ? newValue : dt.Second
            );
    }
