    using System;
    using System.Globalization;
    namespace TwoCurrencySymbols
    {
      internal sealed class Currency : IFormattable
      {
        private readonly IFormattable value;
        public Currency(IFormattable myValue)
        {
          value = myValue;
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
          if (format == "C")
          {
            return ("EUR " + value.ToString(format, formatProvider));
          }
          return value.ToString(format, formatProvider);
        }
      }
      internal static class Program
      {
        private static void Main()
        {
          Console.WriteLine(string.Format(CultureInfo.CurrentCulture, "{0:C}", new Currency(1)));
        }
      }
    }
