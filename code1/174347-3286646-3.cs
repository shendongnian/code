    static void Main(string[] args)
    {
        decimal diff;
        diff = monthDifference(new DateTime(2001, 1, 1), new DateTime(2002, 3, 15));
        Console.WriteLine(diff.ToString("n2")); //14.45
        diff = monthDifference(new DateTime(2001, 1, 1), new DateTime(2001, 4, 16));
        Console.WriteLine(diff.ToString("n2")); //3.50
        diff = monthDifference(new DateTime(2001, 7, 5), new DateTime(2002, 7, 10));
        Console.WriteLine(diff.ToString("n2")); //12.16
        Console.Read();
    }
    static decimal monthDifference(DateTime d1, DateTime d2)
    {
        if (d1 > d2)
        {
            DateTime hold = d1;
            d1 = d2;
            d2 = hold;
        }
        int monthsApart = Math.Abs(12 * (d1.Year-d2.Year) + d1.Month - d2.Month) - 1;
        decimal daysInMonth1 = DateTime.DaysInMonth(d1.Year, d1.Month);
        decimal daysInMonth2 = DateTime.DaysInMonth(d2.Year, d2.Month);
        decimal dayPercentage = ((daysInMonth1 - d1.Day) / daysInMonth1)
                              + (d2.Day / daysInMonth2);
        return monthsApart + dayPercentage;
    }
