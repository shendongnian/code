    class Day
    {
        public IEnumerable days
        {
            get
            {
                return new string[] { "mon", "tue", "wed", "thu", "fri", "sat", "sun" };
            }
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Day d = new Day();
            foreach (string day in d.days)
            {
                Console.WriteLine(day);
            }
        }
    }
