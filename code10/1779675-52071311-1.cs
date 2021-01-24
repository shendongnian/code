    public static class ArabicToRoman
    {
        private static string[] Tausender =  { "", "M", "MM", "MMM" };
        private static string[] Hunderter = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        private static string[] Zehner = { "", "X", "XX", "XXX", "XL", "L", "LX" , "LXX", "LXXX", "XC" };
        private static string[] Einer = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
        public static string Convert(int arabic)
        {
            ...
        }
    }
