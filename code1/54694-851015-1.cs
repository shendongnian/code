    public static class Percent {
        static string LOCAL_PERCENT = "%";
        static Regex PARSE_RE = new Regex(@"([\d\.,]+)\s*("+LOCAL_PERCENT+")?");
        public static double Parse(string str) {
            var m = PARSE_RE.Match(str);
            if (m.Success) {
                double val = 0.0;
                if (!double.TryParse(m.Groups[1].Value, out val)) {
                    throw new FormatException("Cannot parse: " + str);
                }
                bool perc = (m.Groups[2].Value == LOCAL_PERCENT);
                perc = perc || (!perc && val > 1.0);
                return perc ? val : val * 100.0;
            }
            else {
                throw new FormatException("Cannot parse: " + str);
            }
        }
        public static double ParsePercent(this string str) {
            return Parse(str);
        }
    }
