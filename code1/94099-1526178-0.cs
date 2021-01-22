public static class DateTimeExtensions
{
    public static int TotalMonths(this DateTime start, DateTime end)
    {
        return (start.Year * 100 + start.Month) - (end.Year * 100 + end.Month);
    }
}
//  Console.WriteLine(
//     DateTime.Now.TotalMonths(
//         DateTime.Now.AddMonths(-1))); // prints "1"
