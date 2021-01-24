    public class ArabicNumberFormatProvider : IFormatProvider, ICustomFormatter
    {
        public static readonly ArabicNumberFormatProvider Instance =
            new ArabicNumberFormatProvider();
        private ArabicNumberFormatProvider() { }
        public object GetFormat(Type formatType) { return this; }
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            switch (arg) {
                case long l:
                    return ToArabic(l);
                case int i:
                    return ToArabic(i);
                default:
                    return null;
            }
        }
        public static string ToArabic(long num)
        {
            const string _arabicDigits = "۰۱۲۳۴۵۶۷۸۹";
            return new string(num.ToString().Select(c => _arabicDigits[c - '0']).ToArray());
        }
    }
