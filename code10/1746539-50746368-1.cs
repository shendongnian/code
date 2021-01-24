    public static class StringExtensions
    {
        public static string ToLength(this string self, int length)
        {
            if(self == null)
               return null;
               
            return self.Length > length ? self.Substring(0, length) : self.PadRight(length);
        }
    }
