    static class Extension {
        public static bool TryParse<T>(this string text, out T result, IFormatProvider formatProvider) where T : struct {
            result = default(T);
            try {
                result = (T)Convert.ChangeType(text, typeof(T), formatProvider);
                return true;
            } catch {
                return false;
            }
        }
    }
    class Program {
        static void Main(string[] args) {
            CultureInfo c = new CultureInfo("fr-FR");
            double d = 0;
            // NumberGroupSeparator in fr-FR culture is space
            bool res = "123 456,78".TryParse<double>(out d, c);
            // Set separator as '.' and parse string with dots
            c.NumberFormat.NumberGroupSeparator = ".";
            res = "123.456,78".TryParse<double>(out d, c);
        }
    }
