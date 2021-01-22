    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          DateTime localNow = DateTime.Now;
          int year = localNow.Year;
          int month = localNow.Month;
          int day = localNow.Day;
          int hour = localNow.Hour;
          int min = localNow.Minute;
          int sec = localNow.Second;
          DateTime date1 = new DateTime(year, month, day, hour, min, sec);
          Console.WriteLine(date1.ToString());
          Console.WriteLine(date1.ToString("t"));
          Console.WriteLine(date1.ToString("T"));
          Console.WriteLine(date1.TimeOfDay);
        }
      }
    } 
