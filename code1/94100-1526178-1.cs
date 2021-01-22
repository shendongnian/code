public static class DateTimeExtensions
{
    public static int TotalMonths(this DateTime start, DateTime end)
    {
        return (start.Year * 12 + start.Month) - (end.Year * 12 + end.Month);
    }
}
//  Console.WriteLine(
//     DateTime.Now.TotalMonths(
//         DateTime.Now.AddMonths(-1))); // prints "1"
