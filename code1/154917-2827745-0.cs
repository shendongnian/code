    using System;
    class Program {
        static void Main(string[] args) {
            int year = 2010;
            int month = 05;
            DateTime thirdMonday = ThirdMonday(year, month);
        }
        private static DateTime ThirdMonday(int year, int month) {
            for (int day = 1; day <= DateTime.DaysInMonth(year, month); ++day) {
                DateTime dt = new DateTime(year, month, day);
                if (dt.DayOfWeek == DayOfWeek.Monday) {
                    return dt.AddDays(14);
                }
            }
            // this should never happen
            throw new Exception();
        }
    }
