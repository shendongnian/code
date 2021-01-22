    namespace ExtensionMethods
        using System.Globalization;
        public static class DateTimeExtensions
        {
            public static DateTime ToDateTime(
                this string strFdate, 
                string format = "ddMMyyyy")
            {
                var r = DateTime.ParseExact(
                    strFdate,
                    format, 
                    CultureInfo.InvariantCulture);
                return r;
            }
        }
    }
