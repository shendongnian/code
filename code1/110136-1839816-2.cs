    public class CustomStringFormat : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string result = arg.ToString();
            switch (format.ToUpper())
            {
                case "U": return result.ToUpper();
                case "L": return result.ToLower();
                //more custom formats
                default: return result;
            }
        }
    }
