    public static class Helpers
    {
        public static int ToInt(Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }
    }
        static void Main(string[] args)
        {
            Console.WriteLine(Helpers.ToInt(DayOfWeek.Friday));
        }
