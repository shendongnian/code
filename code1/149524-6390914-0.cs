    public static string Render(this HtmlAnchor TheAnchor)
    {
    	StringWriter sw = new StringWriter();
    	HtmlTextWriter htmlWriter = new HtmlTextWriter(sw);
    	TheAnchor.RenderControl(htmlWriter);
    	return sw.ToString(); 
    }
