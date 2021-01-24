    private class MyClass : IFormattable
    {
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "I am called. format: " + format;
        }
    }
