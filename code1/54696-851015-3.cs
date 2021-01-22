    public static class Percent {
        static string LOCAL_PERCENT = "%";
        static Regex PARSE_RE = new Regex(@"([\d\.,]+)\s*("+LOCAL_PERCENT+")?");
        public static bool TryParse(string str, out double ret) {
            var m = PARSE_RE.Match(str);
            if (m.Success) {
                double val;
                if (!double.TryParse(m.Groups[1].Value, out val)) {
                    ret = 0.0;
                    return false;
                }
                bool perc = (m.Groups[2].Value == LOCAL_PERCENT);
                perc = perc || (!perc && val > 1.0);
                ret = perc ? val : val * 100.0;
                return true;
            }
            else {
                ret = 0.0;
                return false;
            }
        }
        public static double Parse(string str) {
            double ret;
            if (!TryParse(str, out ret)) {
                throw new FormatException("Cannot parse: " + str);
            }
            return ret;
        }
        public static double ParsePercent(this string str) {
            return Parse(str);
        }
    }
