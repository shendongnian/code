    public static class SIPrefix
    {
        private static List<SIPrefixInfo> _SIPrefixInfoList = new
            List<SIPrefixInfo>();
        static SIPrefix()
        {
            _SIPrefixInfoList = new List<SIPrefixInfo>();
            LoadSIPrefix();
        }
        public static List<SIPrefixInfo> SIPrefixInfoList
        { 
            get 
            { 
                SIPrefixInfo[] siPrefixInfoList = new SIPrefixInfo[6];
                _SIPrefixInfoList.CopyTo(siPrefixInfoList);
                return siPrefixInfoList.ToList();
            }
        }
        private static void LoadSIPrefix()
        {
            _SIPrefixInfoList.AddRange(new SIPrefixInfo[]{
                new SIPrefixInfo() {Symbol = "Y", Prefix = "yotta", Example = 1000000000000000000000000.00M, ZeroLength = 24, ShortScaleName = "Septillion", LongScaleName = "Quadrillion"},
                new SIPrefixInfo() {Symbol = "Z", Prefix = "zetta", Example = 1000000000000000000000M, ZeroLength = 21, ShortScaleName = "Sextillion", LongScaleName = "Trilliard"},
                new SIPrefixInfo() {Symbol = "E", Prefix = "exa", Example = 1000000000000000000M, ZeroLength = 18, ShortScaleName = "Quintillion", LongScaleName = "Trillion"},
                new SIPrefixInfo() {Symbol = "P", Prefix = "peta", Example = 1000000000000000M, ZeroLength = 15, ShortScaleName = "Quadrillion", LongScaleName = "Billiard"},
                new SIPrefixInfo() {Symbol = "T", Prefix = "tera", Example = 1000000000000M, ZeroLength = 12, ShortScaleName = "Trillion", LongScaleName = "Billion"},
                new SIPrefixInfo() {Symbol = "G", Prefix = "giga", Example = 1000000000M, ZeroLength = 9, ShortScaleName = "Billion", LongScaleName = "Milliard"},
                new SIPrefixInfo() {Symbol = "M", Prefix = "mega", Example = 1000000M, ZeroLength = 6, ShortScaleName = "Million", LongScaleName = "Million"},
                new SIPrefixInfo() {Symbol = "K", Prefix = "kilo", Example = 1000M, ZeroLength = 3, ShortScaleName = "Thousand", LongScaleName = "Thousand"},
                new SIPrefixInfo() {Symbol = "h", Prefix = "hecto", Example = 100M, ZeroLength = 2, ShortScaleName = "Hundred", LongScaleName = "Hundred"},
                new SIPrefixInfo() {Symbol = "da", Prefix = "deca", Example = 10M, ZeroLength = 1, ShortScaleName = "Ten", LongScaleName = "Ten"},
                new SIPrefixInfo() {Symbol = "", Prefix = "", Example = 1M, ZeroLength = 0, ShortScaleName = "One", LongScaleName = "One"},
            });
        }
        public static SIPrefixInfo GetInfo(long amount, int decimals)
        {
            return GetInfo(Convert.ToDecimal(amount), decimals);
        }
        public static SIPrefixInfo GetInfo(decimal amount, int decimals)
        {
            SIPrefixInfo siPrefixInfo = null;
            decimal amountToTest = Math.Abs(amount);
            
            var amountLength = amountToTest.ToString("0").Length;
            if(amountLength < 3)
            {
                siPrefixInfo = _SIPrefixInfoList.Find(i => i.ZeroLength == amountLength).Clone() as SIPrefixInfo;
                siPrefixInfo.AmountWithPrefix =  Math.Round(amount, decimals).ToString();
                return siPrefixInfo;
            }
            siPrefixInfo = _SIPrefixInfoList.Find(i => amountToTest > i.Example).Clone() as SIPrefixInfo;
            siPrefixInfo.AmountWithPrefix = Math.Round(
                amountToTest / Convert.ToDecimal(siPrefixInfo.Example), decimals).ToString()
                                            + siPrefixInfo.Symbol;
            return siPrefixInfo;
        }
    }
    public class SIPrefixInfo : ICloneable
    {
        public string Symbol { get; set; }
        public decimal Example { get; set; }
        public string Prefix { get; set; }
        public int ZeroLength { get; set; }
        public string ShortScaleName { get; set; }
        public string LongScaleName { get; set; }
        public string AmountWithPrefix { get; set; }
        public object Clone()
        {
            return new SIPrefixInfo()
                                {
                                    Example = this.Example,
                                    LongScaleName = this.LongScaleName,
                                    ShortScaleName = this.ShortScaleName,
                                    Symbol = this.Symbol,
                                    Prefix = this.Prefix,
                                    ZeroLength = this.ZeroLength
                                };
        }
    }
