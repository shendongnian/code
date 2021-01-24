    public static IHtmlString Image(this HtmlHelper helper, object htmlAttributes)
    {
        TagBuilder tb = new TagBuilder("img");
        RouteValueDictionary htmlAttrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
        foreach (var thisAttribute in htmlAttrs)
        {
            tb.Attributes.Add(thisAttribute.Key, thisAttribute.Value.ToString());
        }
        
        return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
    }
