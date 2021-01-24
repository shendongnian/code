        static void Main(string[] args)
        {
            string time = "00:00:01:347"; // I removed the microsecond for brevity
            DateTime dt = DateTime.ParseExact(time, "hh:mm:ss:fff", CultureInfo.InvariantCulture);
            
            Console.WriteLine(dt.TimeOfDay.TotalSeconds); // 01.347(totalsecond.fff)
            Console.ReadLine();
        }
