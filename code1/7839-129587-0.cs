    public static class DoubleExtensions
    {
        public static string Format(this double d)
        {
            return String.Format("{0:c}", Math.Round(d));
        }
    }
