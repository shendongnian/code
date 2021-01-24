    using System;
    using System.Globalization;
    class MainClass {
      public static void Main (string[] args) {
        var format = "1234-10-30";
        var date = DateTime.ParseExact(format, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        Console.WriteLine (date.ToString("dd/MM/yyyy"));
      }
    }
