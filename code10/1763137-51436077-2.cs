    public static class HelpExt
    {
    	public static MvcHtmlString CustomerLink<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, 
    		string url, 
    		object htmlAttributes)
    	{
    		TagBuilder builder = new TagBuilder("a");
    		builder.MergeAttribute("src", url);
    		builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
    		return MvcHtmlString.Create(builder.ToString());
    	}
    }
