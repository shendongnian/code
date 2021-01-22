    class MyFormatProvider : IFormatProvider
    {
        public object GetFormat(Type formatType)
        {
            Console.WriteLine("Asked for {0}", formatType);
            if (formatType == typeof(ICustomFormatter))
                return new MyCustomFormatter();
            return CultureInfo.CurrentCulture.GetFormat(formatType);
        }
    }
    
    class MyCustomFormatter : ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider provider)
        {
            return string.Format("(format was \"{0}\")", format);
        }
    }
