    public static class Extension
    {
        public static int GetTwelveCycleHour(this DateTime dateTime)
        {
            if (dateTime.Hour > 12)
            {
                return dateTime.Hour - 12;
            }
    
            return dateTime.Hour;
        }
    }
