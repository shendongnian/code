public class DateAndHourComparer : IEqualityComparer<DateTime>
{
    public bool Equals(DateTime x, DateTime y)
    {
        var xAsDateAndHours = AsDateHoursAndMinutes(x);
        var yAsDateAndHours = AsDateHoursAndMinutes(y);
        return xAsDateAndHours.Equals(yAsDateAndHours);
    }
    private DateTime AsDateHoursAndMinutes(DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, 
                            dateTime.Day, dateTime.Hour, 
                            dateTime.Minute, 0);
    }
    public int GetHashCode(DateTime obj)
    {
        return AsDateHoursAndMinutes(obj).GetHashCode();
    }
}
