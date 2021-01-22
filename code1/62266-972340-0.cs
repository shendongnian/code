        static void Main(string[] args)
        {
            foreach (int value in Enum.GetValues(typeof(DaysOfWeek)))
            {
                Console.WriteLine(((DaysOfWeek)value).ToString());
            }
            foreach (string value in Enum.GetNames(typeof(DaysOfWeek)))
            {
                Console.WriteLine(value);
            }
            Console.ReadLine();
        }
        public enum DaysOfWeek
        {
            monday,
            tuesday,
            wednesday
        }
    }
