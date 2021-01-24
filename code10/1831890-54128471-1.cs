`
public static class DatetimeExtension
{
    public static int RemoveWeekends(this DateTime date)
    {
        while(date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        {
            date = date.AddDays(-1);
        }
        return date.Day;
    }
}
`
i.e. Look at the date and keep moving back by 1 day until such time as the `DayOfWeek` is not Saturday or Sunday.
If you run it with this test:
`
var date = new DateTime(2019, 01, 13); // this is Sunday 13th January 2019
var result = date.RemoveWeekends();
`
It should return `11` which is Friday, i.e. tomorrow.
This is a little inefficient though, as for a Sunday it'll result in `AddDays` being called twice, resulting in two new instances of `DateTime` being created. A version that doesn't have this overhead would be:
`
public static int RemoveWeekends(this DateTime date)
{
    switch (date.DayOfWeek)
    {
        case DayOfWeek.Saturday:
            date = date.AddDays(-1);
            break;
        case DayOfWeek.Sunday:
            date = date.AddDays(-2);
            break;
    }
    return date.Day;
}
`
