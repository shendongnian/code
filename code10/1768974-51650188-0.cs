    public static class ParseExtensions {
        public static int? ParseInt(this string input)
        {
            if(Int32.TryParse(input,out var result)
            {
               return result;
            }
            return null;
        }
    
        public static DateTime? ParseDateTime(this string input)
        {
            if(DateTime.TryParse(input, out var result)
            {
                return result;
            }
            return null;
        }
    }
