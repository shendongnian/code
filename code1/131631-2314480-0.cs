    class Program
    {
        public static void Main(string[] args)
        {
            int digits = 7;
            var format = new PaddedNumberFormatInfo(digits);
            Console.WriteLine(String.Format(format, "{0}", 123));
        }
    }
    class PaddedNumberFormatInfo : IFormatProvider, ICustomFormatter
    {
        public PaddedNumberFormatInfo(int digits)
        {
            this.DigitsCount = digits;
        }
    
        public int DigitsCount { get; set; }
    
        // IFormatProvider Members
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
    
            return null;
        }
        // ICustomFormatter Members
        public string Format(string format, object arg, IFormatProvider provider)
        {
            return String.Format(
                String.Concat("{0, ", this.DigitsCount, "}"), arg);
        }
    }
