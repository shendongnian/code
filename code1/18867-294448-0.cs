    public static class MyWebAppExtensions
    {
        public static string FormatCurrency(this decimal d)
        {
            return d.ToString("c");
        }
    }
