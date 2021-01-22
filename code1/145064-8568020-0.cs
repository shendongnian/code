    public static class StringExtensions
    {
        public static bool ToBool(this string value,string trueValue)
        {
            if (value == trueValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
