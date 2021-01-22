    public class Converter
    {
        public static double Convert(double original, Func<double, double> conversion)
        {
            return conversion(original);
        }
    }
    public class SizeConverter
    {
        public static double MegabytesToBytes(double megabytes)
        {
            return megabytes * 1048576;
        }
        public static double KilobytesToBytes(double kilobytes)
        {
            return kilobytes * 1024;
        }
    }
