    public static class DateTimeExtension
    {
      public static DateTime GetFirstDayOfThisWeek(this DateTime d)
      {
        CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
        var first = (int)ci.DateTimeFormat.FirstDayOfWeek;
        var current = (int)d.DayOfWeek;
    
        var result = first <= current ?
          d.AddDays(-1 * (current - first)) :
          d.AddDays(first - current - 7);
    
        return result;
      }
    }
    class Program
    {
      static void Main()
      {
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        Console.WriteLine("Current culture set to en-US");
        RunTests();
        Console.WriteLine();
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("da-DK");
        Console.WriteLine("Current culture set to da-DK");
        RunTests();
        Console.ReadLine();
      }
    
      static void RunTests()
      {
        Console.WriteLine("Today {1}: {0}", DateTime.Today.Date.GetFirstDayOfThisWeek(), DateTime.Today.Date.ToString("yyyy-MM-dd"));
        Console.WriteLine("Saturday 2013-03-02: {0}", new DateTime(2013, 3, 2).GetFirstDayOfThisWeek());
        Console.WriteLine("Sunday 2013-03-03: {0}", new DateTime(2013, 3, 3).GetFirstDayOfThisWeek());
        Console.WriteLine("Monday 2013-03-04: {0}", new DateTime(2013, 3, 4).GetFirstDayOfThisWeek());
      }
    }
