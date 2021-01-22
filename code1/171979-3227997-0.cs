    class Program
    {
        static void Main(string[] args)
        {
            GetDates(new DateTime(2010, 1, 1), new DateTime(2010, 2, 5));
            Console.ReadKey();
        }
        static List<DateTime> GetDates(DateTime startDate, DateTime endDate)
        {
            List<DateTime> dates = new List<DateTime>();
            while ((startDate = startDate.AddDays(1)) < endDate)
            {
                dates.Add(startDate);
            }
            return dates;
        }
    }
