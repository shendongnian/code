    internal class RatioFormatProvider : IFormatProvider, ICustomFormatter
    {
        public static readonly RatioFormatProvider Instance = new RatioFormatProvider();
        private RatioFormatProvider()
        {
            
        }
        #region IFormatProvider Members
        public object GetFormat(Type formatType)
        {
            if(formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            return null;
        }
        #endregion
        #region ICustomFormatter Members
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string result = arg.ToString();
            switch(format.ToUpperInvariant())
            {
                case "RATIO":
                    return (result == "0") ? result : "1:" + result;
                default:
                    return result;
            }
        }
        #endregion
    }
