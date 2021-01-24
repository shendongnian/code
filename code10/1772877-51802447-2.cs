    public class ArabicNumberFormatProvider : IFormatProvider, ICustomFormatter
    {
        private static readonly char[] _arabicDigits =
            new[] { '\u06f0', '\u06f1', '\u06f2', '\u06f3', '\u06f4',
                    '\u06f5', '\u06f6', '\u06f7', '\u06f8', '\u06f9' };
        public static readonly ArabicNumberFormatProvider Instance =
            new ArabicNumberFormatProvider();
        private ArabicNumberFormatProvider() { }
        public object GetFormat(Type formatType) => this;
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
            return new string(num.ToString().Select(c => _arabicDigits[c - '0']).ToArray());
        }
    }
