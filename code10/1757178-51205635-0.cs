    public class CustomBinding : Binding
    {
        private static readonly CultureInfo cultureInfo;
        static CustomBinding()
        {
            cultureInfo = new CultureInfo("sv");
            cultureInfo.NumberFormat.NumberDecimalDigits = 2;
            cultureInfo.NumberFormat.NumberDecimalSeparator = ",";
            cultureInfo.NumberFormat.NumberGroupSeparator = ".";
            cultureInfo.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
            cultureInfo.DateTimeFormat.FullDateTimePattern = "dd.MM.yyyy";
            cultureInfo.DateTimeFormat.ShortTimePattern = "HH:mm";
            cultureInfo.DateTimeFormat.LongDatePattern = "dd.MM.yyyy";
            cultureInfo.DateTimeFormat.LongTimePattern = "HH:mm";
        }
        public CustomBinding()
        {
            ConverterCulture = cultureInfo;
        }
        public CustomBinding(string path)
            : base(path)
        {
            ConverterCulture = cultureInfo;
        }
    }
