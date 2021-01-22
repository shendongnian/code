    using System;
    using System.Globalization;
    
    class MyCustomObject : IFormattable
    {
        public string ToString(string format, IFormatProvider provider)
        {
            Console.WriteLine("ToString(\"{0}\", provider) called", format);
            return "arbitrary value";
        }
    }
    
    class MyFormatProvider : IFormatProvider
    {
        public object GetFormat(Type formatType)
        {
            Console.WriteLine("Asked for {0}", formatType);
            return CultureInfo.CurrentCulture.GetFormat(formatType);
        }
    }
    
    class App
    {
        static void Main()
        {
            Console.WriteLine(
                string.Format(new MyFormatProvider(), "{0:foobar}", 
                    new MyCustomObject()));
        }
    }
   
    
