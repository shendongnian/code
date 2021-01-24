    public static class Extensions
    {
        public static string ToStringWithSpaces(this int number)
        {
            var numStr = number.ToString();
            var len = numStr.Length;
            var result = new StringBuilder();
            for (var i = 0; i < len; i++)
            {
                if (i > 0 && i % 3 == 0) result.Insert(0, " ");
                result.Insert(0, numStr[len - 1 - i]);
            }
            return result.ToString();
        }
    }
