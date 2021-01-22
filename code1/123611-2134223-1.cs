    public class KiloFormatter: ICustomFormatter, IFormatProvider
    {
        public object GetFormat(Type formatType)
        {
            return (formatType == typeof(ICustomFormatter)) ? this : null;
        }
    
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (format == null || !format.Trim().StartsWith("K")) {
                if (arg is IFormattable) {
                    return ((IFormattable)arg).ToString(format, formatProvider);
                }
                return arg.ToString();
            }
    
            decimal value = Convert.ToDecimal(arg);
            
            //  Here's is where you format your number
            
            if (value > 1000) {
                return (value / 1000).ToString() + "k";
            }
    
            return value.ToString();
        }
    }
