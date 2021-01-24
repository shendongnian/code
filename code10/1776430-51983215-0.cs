    public class StringDateConverter : ValueConverter<DateTime?, string>
    {
        // these can be overridden
        public static string StringDateStorageType = "char(8)";
        public static string StringDateStorageFormat = "yyyyMMdd";
        public static string StringDateEmptyValue = "00000000";
        protected static readonly ConverterMappingHints _defaultHints
            = new ConverterMappingHints(size: 48);
        public StringDateConverter()
            : base(ToString(), ToDateTime(), _defaultHints)
        {
        }
        protected new static Expression<Func<DateTime?, string>> ToString()
            => v => DateToString(v);
        protected static Expression<Func<string, DateTime?>> ToDateTime()
            => v => StringToDate(v);
        private static string DateToString(DateTime? date)
        {
            if (date.HasValue)
                return date.Value.ToString(StringDateStorageFormat);
            return StringDateEmptyValue;
        }
        private static DateTime? StringToDate(string date)
        {
            if (!string.IsNullOrWhiteSpace(date) 
                && !(date == StringDateEmptyValue)
                && DateTime.TryParseExact(date, StringDateStorageFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                return result;
            return null;
        }
    }
