    static void Main(string[] args)
    {
        DateTime Date1 = new DateTime(2001, 1, 1);
        DateTime Date2 = new DateTime(2002, 3, 15);
        decimal diff = monthDifference(Date1, Date2);
        Console.Write(diff.ToString("n2"));
        Console.Read();
    }
    static decimal monthDifference(DateTime d1, DateTime d2)
    {
        int monthsApart = Math.Abs(12 * (d1.Year - d2.Year) + d1.Month - d2.Month);
        decimal daysinMonth = DateTime.DaysInMonth(d2.Year, d2.Month);
        return monthsApart + (d2.Day / daysinMonth);
    }
