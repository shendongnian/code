    using System;
    using System.Globalization;
    using System.Threading;
    namespace test {
        public static class Program {
            public static void Main() {
                CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                culture.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
                culture.DateTimeFormat.LongTimePattern = "";
                Thread.CurrentThread.CurrentCulture = culture;
                Console.WriteLine(DateTime.Now);
            }
        }
    }
