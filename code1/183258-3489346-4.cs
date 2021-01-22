    public static class DoubleExtensions
    {
        public static string ToFortranDouble(this double value)
        {
            return value.ToFortranDouble(4);
        }
        public static string ToFortranDouble(this double value, int precision)
        {
            return string.Format(value.ToString(
                string.Format("\\0.{0}E0", new string('#', precision))
                ));
        }
    }
