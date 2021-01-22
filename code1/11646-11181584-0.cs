    public static class NullableExtensions
    {
        public static bool TryParse(this DateTime? dateTime, string dateString, out DateTime? result)
        {
            DateTime tempDate;
            if(! DateTime.TryParse(dateString,out tempDate))
            {
                result = null;
                return false;
            }
            result = tempDate;
            return true;
            
        }
    }
