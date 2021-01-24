    // custom formatter class
    public class FormatD : IFormattable
    {
        public string ToString(string format, IFormatProvider provider)
        {
            return format[0] + "-" + format.Substring(1,3) + "-" + format.Substring(4);
        }
    }
