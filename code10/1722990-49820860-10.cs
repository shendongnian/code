    public static class Extensions
    {
        public static string ToCustomString(this int number, 
            int position = 3, string separator = " ")
        {
            var numStr = number.ToString();
            var len = numStr.Length;
            var result = new StringBuilder();
            for (var i = 0; i < len; i++)
            {
                if (i > 0 && i % position == 0) result.Insert(0, separator);
                result.Insert(0, numStr[len - 1 - i]);
            }
            return result.ToString();
        }
    }
