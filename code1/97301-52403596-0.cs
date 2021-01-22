    private int getSeason(DateTime date)
        {
            bool lastYearIsLeap = DateTime.IsLeapYear(date.Year-1);
            bool thisIsLeap = DateTime.IsLeapYear(date.Year);
            bool nextYearIsLeap = DateTime.IsLeapYear(date.Year+1);
            float summerStart = 6.21f;
            float autumnStart = 9.23f;
            float winterStart = 12.21f;
            //check summer adjustment
            if (thisIsLeap)
            {
                summerStart = 6.20f;
            }
            //check autumn adjustment
            if (thisIsLeap || lastYearIsLeap)
            {
                autumnStart = 9.22f;
            }
            //check if we need winter adjustments
            if (nextYearIsLeap)
            {
                winterStart = 12.22f;
            }
            if (date.Year == 2034 || date.Year == 2038)
                autumnStart -= 0.01f;
            float value = (float)date.Month + date.Day / 100f;   // <month>.<day(2 digit)>
            if (value < 3.20 || value >= winterStart) return 3;   // Winter
            if (value < summerStart) return 0; // Spring
            if (value < autumnStart) return 1; // Summer
            return 2;   // Autumn
           
        }
