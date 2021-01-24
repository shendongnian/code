    static void Main(string[] args)
        {
            List<DateTime> times = new List<DateTime>();
            times.Add(new DateTime(2012, 02, 19, 10, 06, 29));
            times.Add(new DateTime(2012, 02, 19, 10, 06, 29));
            times.Add(new DateTime(2014, 01, 21, 15, 21, 11));
            times.Add(new DateTime(2015, 04, 22, 01, 11, 50));
            times.Add(new DateTime(2015, 04, 22, 01, 11, 55));
            times.Add(new DateTime(2015, 04, 22, 01, 12, 12));
            times.Add(new DateTime(2017, 12, 18, 12, 01, 01));
            List<DateTime> TheList = new List<DateTime>();
            DateTime min = times.OrderBy(c => c.Date).ThenBy(c => c.TimeOfDay).FirstOrDefault();
           
            while (times.Where(t => t <= min.AddMinutes(1)).Any())
            { 
                TheList.Add(min);
                Remove(times, min);
                min = times.OrderBy(c => c.Date).ThenBy(c => c.TimeOfDay).FirstOrDefault();
            }
            foreach (DateTime t in TheList)
                Console.WriteLine(t);
            Console.ReadKey();
        }
        static void Remove(List<DateTime> times, DateTime min)
        {
            times.RemoveAll(t => t <= min.AddMinutes(1));
        }
