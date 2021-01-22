    public static class MyHelpers
    {
        public static string OutputBlah(this HtmlHelper helper)
        {
            return helper.InnerWriter.ToString();
        }
    }
