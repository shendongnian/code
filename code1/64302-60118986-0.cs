CSharp
public static DateTime Truncate(this DateTime dateTime, long ticks)
{
    bool isValid = ticks == TimeSpan.TicksPerDay 
        || ticks == TimeSpan.TicksPerHour 
        || ticks == TimeSpan.TicksPerMinute 
        || ticks == TimeSpan.TicksPerSecond 
        || ticks == TimeSpan.TicksPerMillisecond;
    // https://stackoverflow.com/questions/21704604/have-datetime-now-return-to-the-nearest-second
    return isValid 
        ? DateTime.SpecifyKind(
            new DateTime(
                dateTime.Ticks - (dateTime.Ticks % ticks)
            ),
            dateTime.Kind
        )
        : throw new ArgumentException("Invalid ticks value given. Only TimeSpan tick values are allowed.");
}
Then you can use the method like this:
CSharp
DateTime dateTime = DateTime.UtcNow.Truncate(TimeSpan.TicksPerMillisecond);
dateTime.Kind => DateTimeKind.Utc
