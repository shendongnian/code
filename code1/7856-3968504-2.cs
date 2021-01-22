    using System.Globalization;
    public struct FileSize : IFormattable
    {
        private ulong _value;
        private const int DEFAULT_PRECISION = 2;
        private static IList<string> Units;
        static FileSize()
        {
            Units = new List<string>(){
                "B", "KB", "MB", "GB", "TB"
            };
        }
        public FileSize(ulong value)
        {
            _value = value;
        }
        public static explicit operator FileSize(ulong value)
        {
            return new FileSize(value);
        }
        
        override public string ToString()
        {
            return ToString(null, null);
        }
        public string ToString(string format)
        {
            return ToString(format, null);
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            int precision;
            if (String.IsNullOrEmpty(format))
                return ToString(DEFAULT_PRECISION);
            else if (int.TryParse(format, out precision))
                return ToString(precision);
            else
                return _value.ToString(format, formatProvider);
        }
        /// <summary>
        /// Formats the FileSize using the given number of decimals.
        /// </summary>
        public string ToString(int precision)
        {
            double pow = Math.Floor((_value > 0 ? Math.Log(_value) : 0) / Math.Log(1024));
            pow = Math.Min(pow, Units.Count - 1);
            double value = (double)_value / Math.Pow(1024, pow);
            return value.ToString(pow == 0 ? "F0" : "F" + precision.ToString()) + " " + Units[(int)pow];
        }
    }
