    namespace Extensions.DateTime
    {
        public static class BusinessDays
        {
            public static System.DateTime AddBusinessDays(this System.DateTime source, int businessDays)
            {
                var dayOfWeek = businessDays < 0
                                    ? ((int)source.DayOfWeek - 12) % 7
                                    : ((int)source.DayOfWeek + 6) % 7;
                switch (dayOfWeek)
                {
                    case 6:
                        businessDays--;
                        break;
                    case -6:
                        businessDays++;
                        break;
                }
                return source.AddDays(businessDays + ((businessDays + dayOfWeek) / 5) * 2);
            }
        }
    }
