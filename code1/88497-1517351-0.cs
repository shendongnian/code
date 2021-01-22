    public static class Display // class name really don't matter for extension methods
    {
        public static string CheckBox(this HtmlHelper html)
        {
             return html.CheckBox("Test");
        }
    }
