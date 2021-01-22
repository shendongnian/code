public static bool EqualsIgnoringSeconds(this DateTime source, DateTime target)
{
    return TimeSpan.FromTicks(source.Ticks).TotalMinutes == TimeSpan.FromTicks(target.Ticks).TotalMinutes;
}
hope this helps
