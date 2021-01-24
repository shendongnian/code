    class Program
    {
        static void Main(string[] args)
        {
            var daysOfWeek = GetDaysOfTheWeek(new List<DaysOfTheWeek> {DaysOfTheWeek.Monday, DaysOfTheWeek.Sunday});
            Console.WriteLine(daysOfWeek); //3
        }
        public static DaysOfTheWeek GetDaysOfTheWeek(List<DaysOfTheWeek> selectedDays)
        {
            var daysOfTheWeek = DaysOfTheWeek.None;
            foreach (var day in selectedDays)
            {
                daysOfTheWeek = daysOfTheWeek | day;
            }
            return daysOfTheWeek;
        }
    }
    [Flags]
    public enum DaysOfTheWeek : short
    {
        None = 0,
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64,
        AllDays = 127
    }
