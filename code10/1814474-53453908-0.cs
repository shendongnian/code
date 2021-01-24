    public static class HeaderTagBuilder
        {
            public static string Header2(this HtmlHelper helper, string text, string id)
            {
                return Header2(helper, text,id, null);
            }
    
            public static string Header2(this HtmlHelper helper,string text, string id = null, object htmlAttributes = null)
            {
                // Create tag builder
                var builder = new TagBuilder("h2");
                //add the text
                if (text == null)
                    text = string.Empty;//just create an empty string
    
                builder.SetInnerText(text);
    
                // Create valid id
                builder.GenerateId(id);
    
                // Add attributes
                builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
    
                // Render tag
                return builder.ToString(TagRenderMode.Normal);
            }
