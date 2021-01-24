    public static class MyExtension
    {
        static readonly string[] _sizeSuffixes ={ "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public static string ToSize(this long value, int decimalPlaces = 1)
        {
            if (value < 0) { return "-" + ToSize(-value); }
            var i = 0;
            var dValue = (decimal)value;
            while (Math.Round(dValue, decimalPlaces) >= 1000)
            {
                dValue /= 1024;
                i++;
            }
            return string.Format("{0:n" + decimalPlaces + "} {1}", dValue, _sizeSuffixes[i]);
        }
    }
