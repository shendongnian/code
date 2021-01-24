    public interface IDateTimeProvider
    {
        DateTime GetNow();
    }
    public interface IDateTimeUtcProvider : IDateTimeProvider
    {
    }
