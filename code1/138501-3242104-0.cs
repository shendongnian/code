    static void TestTimeSpan()
        {
            TimeSpan t = TimeSpan.Parse("13:45:43");
            Console.WriteLine(@"Timespan is {0}", String.Format(@"{0:yy\:MM\:dd\:hh\:mm\:ss}", t));
        }
