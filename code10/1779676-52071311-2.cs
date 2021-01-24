    public class ArabicToRoman
    {
        private string[] Tausender =  { "", "M", "MM", "MMM" };
        private string[] Hunderter = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        private string[] Zehner = { "", "X", "XX", "XXX", "XL", "L", "LX" , "LXX", "LXXX", "XC" };
        private string[] Einer = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
        public string Convert(int arabic)
        {
            ...
        }
    }
