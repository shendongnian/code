    public static class DateTimeExtensions
    {
        //http://stackoverflow.com/questions/38039/how-can-i-get-the-datetime-for-the-start-of-the-week
        //http://stackoverflow.com/questions/1788508/calculate-date-with-monday-as-dayofweek1
        public static DateTime StartOfWeek(this DateTime dt)
        {
            //difference in days
            int diff = (int)dt.DayOfWeek - (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek; //sunday=always0, monday=always1, etc.
            //As a result we need to have day 0,1,2,3,4,5,6 
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }
        public static int DayNoOfWeek(this DateTime dt)
        {
            //difference in days
            int diff = (int)dt.DayOfWeek - (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek; //sunday=always0, monday=always1, etc.
            //As a result we need to have day 0,1,2,3,4,5,6 
            if (diff < 0)
            {
                diff += 7;
            }
            return diff + 1; //Make it 1..7
        }
    }
