    public static class DateTimeUtil //or whatever name
    {
        public static bool IsEmpty(this DateTime dateTime)
        {
            return dateTime == default(DateTime);
        }
    }
   
