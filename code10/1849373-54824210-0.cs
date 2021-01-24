public static DateTime LastThursday(this DateTime time)
{
    DateTime date = new DateTime(time.Year, time.Month, 1).AddMonths(1).AddDays(-1);
    while (date.DayOfWeek != DayOfWeek.Thursday) {
        date = date.AddDays(-1);
    }
    return date;
}
Can be called like 
DateTime x = new DateTime(2019, 4, 22);
Console.WriteLine(x.LastThursday());
