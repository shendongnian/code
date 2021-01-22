      public static int GetWorkdays(DateTime from ,DateTime to)
        {
            int limit = 9999;
            int counter = 0;
            DateTime current = from;
            int result = 0;
            if (from > to)
            {
                DateTime temp = from;
                from = to;
                to = temp;
            }
            if (from >= to)
            {
                return 0;
            }
            while (current <= to && counter < limit)
            {
                if (IsSwedishWorkday(current))
                {
                    result++;
                }
                current = current.AddDays(1);
                counter++;
            }
            return result;
        }
        public static bool IsSwedishWorkday(DateTime date)
        {
            return (!IsSwedishHoliday(date) && date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday);
        }
        public static bool IsSwedishHoliday(DateTime date)
        {
            return (
            IsSameDay(GetEpiphanyDay(date.Year), date) ||
            IsSameDay(GetMayDay(date.Year), date) ||
            IsSameDay(GetSwedishNationalDay(date.Year), date) ||
            IsSameDay(GetChristmasDay(date.Year), date) ||
            IsSameDay(GetBoxingDay(date.Year), date) ||
            IsSameDay(GetGoodFriday(date.Year), date) ||
            IsSameDay(GetAscensionDay(date.Year), date) ||
            IsSameDay(GetAllSaintsDay(date.Year), date) ||
            IsSameDay(GetMidsummersDay(date.Year), date) ||
            IsSameDay(GetPentecostDay(date.Year), date) ||
            IsSameDay(GetEasterMonday(date.Year), date) ||
            IsSameDay(GetNewYearsDay(date.Year), date) ||
            IsSameDay(GetEasterDay(date.Year), date)
            );
        }
        // Trettondagen
        public static DateTime GetEpiphanyDay(int year)
        {
            return new DateTime(year, 1, 6);
        }
        // Första maj
        public static DateTime GetMayDay(int year)
        {
            return new DateTime(year,5,1);
        }
        // Juldagen
        public static DateTime GetSwedishNationalDay(int year)
        {
            return new DateTime(year, 6, 6);
        }
        // Juldagen
        public static DateTime GetNewYearsDay(int year)
        {
            return new DateTime(year,1,1);
        }
        // Juldagen
        public static DateTime GetChristmasDay(int year)
        {
            return new DateTime(year,12,25);
        }
        // Annandag jul
        public static DateTime GetBoxingDay(int year)
        {
            return new DateTime(year, 12, 26);
        }
        // Långfredagen
        public static DateTime GetGoodFriday(int year)
        {
            return GetEasterDay(year).AddDays(-3);
        }
        // Kristi himmelsfärdsdag
        public static DateTime GetAscensionDay(int year)
        {
            return GetEasterDay(year).AddDays(5*7+4);
        }
        // Midsommar
        public static DateTime GetAllSaintsDay(int year)
        {
            DateTime result = new DateTime(year,10,31);
            while (result.DayOfWeek != DayOfWeek.Saturday)
            {
                result = result.AddDays(1);
            }
            return result;
        }
        // Midsommar
        public static DateTime GetMidsummersDay(int year)
        {
            DateTime result = new DateTime(year, 6, 20);
            while (result.DayOfWeek != DayOfWeek.Saturday)
            {
                result = result.AddDays(1);
            }
            return result;
        }
        // Pingstdagen
        public static DateTime GetPentecostDay(int year)
        {
            return GetEasterDay(year).AddDays(7 * 7);
        }
        // Annandag påsk
        public static DateTime GetEasterMonday(int year)
        {
            return GetEasterDay(year).AddDays(1);
        }
        public static DateTime GetEasterDay(int y)
        {
            double c;
            double n;
            double k;
            double i;
            double j;
            double l;
            double m;
            double d;
            c = System.Math.Floor(y / 100.0);
            n = y - 19 * System.Math.Floor(y / 19.0);
            k = System.Math.Floor((c - 17) / 25.0);
            i = c - System.Math.Floor(c / 4) - System.Math.Floor((c - k) / 3) + 19 * n + 15;
            i = i - 30 * System.Math.Floor(i / 30);
            i = i - System.Math.Floor(i / 28) * (1 - System.Math.Floor(i / 28) * System.Math.Floor(29 / (i + 1)) * System.Math.Floor((21 - n) / 11));
            j = y + System.Math.Floor(y / 4.0) + i + 2 - c + System.Math.Floor(c / 4);
            j = j - 7 * System.Math.Floor(j / 7);
            l = i - j;
            m = 3 + System.Math.Floor((l + 40) / 44);// month
            d = l + 28 - 31 * System.Math.Floor(m / 4);// day
            double days = ((m == 3) ? d : d + 31);
            DateTime result = new DateTime(y, 3, 1).AddDays(days-1);
            return result;
        }
