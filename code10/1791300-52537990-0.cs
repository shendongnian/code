    public class InterceptProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
        public string Format(String format, Object obj, IFormatProvider provider)
        {
            string spanText;
            // Use default for all other formatting.
            if (obj is IFormattable)
                spanText = ((IFormattable)obj).ToString(format, System.Globalization.CultureInfo.CurrentCulture);
            else
                spanText = obj.ToString();
            return $"</Span><Span ForegroundColor=\"Red\">{spanText}</Span><Span>";
        }
    }
