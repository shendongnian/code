    using System;
    
    class Program {
      static void Main(string[] args) {
        DateTime dt1 = new DateTime(2009, 12, 31, 23, 0, 0, DateTimeKind.Utc);
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
        Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(dt1, tz));
        DateTime dt2 = new DateTime(2010, 4, 1, 23, 0, 0, DateTimeKind.Utc);
        Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(dt2, tz));
        Console.ReadLine();
      }
    }
