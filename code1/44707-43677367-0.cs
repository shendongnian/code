    public static void WriteNav(this
         HtmlTextWriter writer, List<String> navItems)
        {
            writer.RenderBeginTag("nav");
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);
            foreach (var item in navItems)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Ul);
                writer.AddAttribute(HtmlTextWriterAttribute.Href, "~/" + item + ".html");
                writer.RenderBeginTag(HtmlTextWriterTag.A);
                writer.Write(item);
                writer.RenderEndTag();
                writer.RenderEndTag();
            }
            writer.RenderEndTag();
            writer.RenderEndTag();
        }
