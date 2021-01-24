        public static HtmlString TestHtmlString(this HtmlHelper html, string hText, string pText)
        {
            var h = new TagBuilder("h2");
            var p = new TagBuilder("p");
            h.InnerHtml = hText;
            p.InnerHtml = pText;
            return new HtmlString(h.ToString(TagRenderMode.Normal) + p.ToString(TagRenderMode.Normal));
        }
