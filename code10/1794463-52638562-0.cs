    public static class HtmlHelperExtension {
        public static IHtmlContent MyCustomControl(this IHtmlHelper html)
        {
            var result = new MyCustomControl();
            return html.Raw(result.Render());
        }
    }
