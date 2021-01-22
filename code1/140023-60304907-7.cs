	public static class StringExtensions
    {
        public static string Increment(this string str)
        {
            if (!str.Contains("_"))
            {
                str += "_2";
                return str;
            }
            var number = int.Parse(str.Substring(str.LastIndexOf('_') + 1));            
            var stringBefore = StringFunctions.GetUntilOrEmpty(str, "_");            
            return $"{stringBefore}_{++number}";
        }
    }
