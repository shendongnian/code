    public static class StrToNumberExtensions
    {
        public static short ToShort(this string s, short defaultValue = 0) => short.TryParse(s, out var v) ? v : defaultValue;
        public static int ToInt(this string s, int defaultValue = 0) => int.TryParse(s, out var v) ? v : defaultValue;
        public static long ToLong(this string s, long defaultValue = 0) => long.TryParse(s, out var v) ? v : defaultValue;
        public static decimal ToDecimal(this string s, decimal defaultValue = 0) => decimal.TryParse(s, out var v) ? v : defaultValue;
        public static float ToFloat(this string s, float defaultValue = 0) => float.TryParse(s, out var v) ? v : defaultValue;
        public static double ToDouble(this string s, double defaultValue = 0) => double.TryParse(s, out var v) ? v : defaultValue;
        public static short? ToshortNullable(this string s, short? defaultValue = null) => short.TryParse(s, out var v) ? v : defaultValue;
        public static int? ToIntNullable(this string s, int? defaultValue = null) => int.TryParse(s, out var v) ? v : defaultValue;
        public static long? ToLongNullable(this string s, long? defaultValue = null) => long.TryParse(s, out var v) ? v : defaultValue;
        public static decimal? ToDecimalNullable(this string s, decimal? defaultValue = null) => decimal.TryParse(s, out var v) ? v : defaultValue;
        public static float? ToFloatNullable(this string s, float? defaultValue = null) => float.TryParse(s, out var v) ? v : defaultValue;
        public static double? ToDoubleNullable(this string s, double? defaultValue = null) => double.TryParse(s, out var v) ? v : defaultValue;
    }
