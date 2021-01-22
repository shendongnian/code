    class FormattableType : IFormattable
    {
        private double value = 0.42;
    
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (formatProvider == null)
            {
                // ... using some IOC-containers
                // ... or using CultureInfo.CurrentCulture / Thread.CurrentThread.CurrentCulture
                formatProvider = CultureInfo.InvariantCulture;
            }
    
            // ... doing things with format
            return value.ToString(formatProvider);
        }
    
        public override string ToString()
        {
            return value.ToString();
        }
    }
