    public static class StringExtensions
    {
        public static bool IsHexString(this string str)
        {
            foreach (var c in str)
            {
                var isHex = ((c >= '0' && c <= '9') ||
                              (c >= 'a' && c <= 'f') ||
                              (c >= 'A' && c <= 'F'));
                if (!isHex)
                {
                    return false;
                }
            }
            return true;
        }
        //bonus, verify whether a string can be parsed as byte[]
        public static bool IsParseableToByteArray(this string str)
        {
            return IsHexString(str) && str.Length % 2 == 0;
        }
    }
