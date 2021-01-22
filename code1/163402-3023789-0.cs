    public static class StringExtension
    {
        public static bool TryParseToBoolean(this string value, bool acceptYesNo, out bool result)
        {
            if (acceptYesNo)
            {
                string upper = value.ToUpper();
                if (upper == "YES")
                {
                    result = true;
                    return true;
                }
                if (upper == "NO")
                {
                    result = false;
                    return true;
                }
            }
            return bool.TryParse(value, out result);
        }
    }
