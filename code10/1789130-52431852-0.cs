        public static (double Value, string unit) Parse(string value)
        {
            var result = RegexParseDouble.Match(value);
            if(result.Success)
            {
                return (double.Parse(value.Substring(result.Length)), value.Substring(result.Length));
            }
            throw new FormatException("Value cannot be parsed as a floating point number.");
        }
        private static Regex RegexParseDouble
        {
            get => new Regex(
                @"^[-+]?(\d+" +
                Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator +
                @"\d+)*\d*(" +
                Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator +
                @")?\d+([eE][-+]?\d+)?");
        }
