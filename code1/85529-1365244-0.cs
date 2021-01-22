    class MyFormat : System.IFormatProvider, ICustomFormatter
    {
        #region IFormatProvider Members
        public object GetFormat(Type formatType)
        {
            return this;
        }
        #endregion
        #region ICustomFormatter Members
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is double)
                if (((double)arg >= 10000) || ((double)arg <= -10000))
                    return ((double)arg).ToString(format);
                else
                    return ((double)arg).ToString("R");
            if (arg is decimal)
                if (((decimal)arg >= 10000) || ((decimal)arg <= -10000))
                    return ((decimal)arg).ToString(format);
                else
                    return ((decimal)arg).ToString("R");
            return arg.ToString();
        }
        #endregion
    }
    class Program
    {
        static MyFormat gFormat = new MyFormat();
        static void Main(string[] args)
        {
            double dblVal1 = 9999, dblVal2 = 123456;
            Console.WriteLine(String.Format(gFormat, "{0:N0} {1:N0}", dblVal1, dblVal2));
        }
    }
