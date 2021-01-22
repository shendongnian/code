        static void Main(string[] args) {
            Console.WriteLine(TimeConvertTo());
            Console.WriteLine(TimeParse());
        }
        static TimeSpan TimeConvertTo() {
            TimeSpan start = DateTime.Now.TimeOfDay;
            for (int i = 0; i < 99999999; i++) {
                Convert.ToInt32("01234");
            }
            return DateTime.Now.TimeOfDay.Subtract(start);
        }
        static TimeSpan TimeParse() {
            TimeSpan start = DateTime.Now.TimeOfDay;
            for (int i = 0; i < 99999999; i++) {
                int.Parse("01234");
            }
            return DateTime.Now.TimeOfDay.Subtract(start);
        }
