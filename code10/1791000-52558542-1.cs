    public interface IDateTimeProvider
    {
        Func<DateTime> Now { get; }
        void SetDateTime(DateTime dateTimeNow);
        void ResetDateTime();
    }
