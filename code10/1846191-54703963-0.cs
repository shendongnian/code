    public static string ToZtring(this IHtmlContent content, bool encode = false)
    {
    	string result = default;
    
    	using (StringWriter sw = new StringWriter())
    	{
    		content.WriteTo(sw, HtmlEncoder.Default);
    
    		result = sw.ToString();
    	}
    
    	if (!encode)
    	{
    		result = HttpUtility.HtmlDecode(result);
    	}
    
    	return result;
    }
    
    TagBuilder opt = new TagBuilder("option");
    opt.Attributes.Add("value", "demo");
    
    @Html.Raw(opt.ToZtring());
