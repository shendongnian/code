    public class HandleBraces : IFormatProvider, ICustomFormatter {
        public string Format(string format, object arg, IFormatProvider formatProvider) =>
            (format != null && format.EndsWith("}")) ? String.Format($"{{0:{format.Substring(0, format.Length - 1)}{'}'}", arg) + "}"
                                                     : null;
    
        public object GetFormat(Type formatType) => this;
    
        static HandleBraces HBFormatter = new HandleBraces();
        public static string Fix(FormattableString fs) => fs.ToString(HBFormatter);
    }
