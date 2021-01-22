    using System.Text.RegularExpressions;
    public static class Extensions
    {
        public static bool IsHex(this char c)
        {
         
            return (new Regex("[A-Fa-f0-9]").IsMatch(c.ToString()));
        }
    }
