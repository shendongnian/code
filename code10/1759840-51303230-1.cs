        public static IHtmlString Image(this HtmlHelper helper, string src, string alt, string height, string width, params string[] allClasses)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tb.Attributes.Add("alt", alt);
            if (!string.IsNullOrEmpty(height) || !string.IsNullOrEmpty(width))
            {
                StringBuilder value = new StringBuilder();
                if (!string.IsNullOrEmpty(height))
                    value.AppendFormat("height:{0};", height);
                if (!string.IsNullOrEmpty(width))
                    value.AppendFormat("width:{0};", width);
                tb.Attributes.Add("style", value.ToString());
            }
            if (allClasses?.Any() ?? false)
                tb.Attributes.Add("class", string.Join(" ", allClasses));
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
