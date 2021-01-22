    static void Main(string[] args)
            {
                var start = new DateTime(2017, 1, 1);
                var due = new DateTime(2017, 12, 31);
    
                var sw = Stopwatch.StartNew();
                var days = NumberOfWorkingDaysBetween2Dates(start, due,NationalHolidays());
                sw.Stop();
    
                Console.WriteLine($"Total working days = {days} --- time: {sw.Elapsed}");
                Console.ReadLine();
    
                // result is:
               // Total working days = 249-- - time: 00:00:00.0269087
            }
