    public static string Image(this HtmlHelper helper, string url)
    {
        var writer = new HtmlTextWriter(new StringWriter());
    
        writer.AddAttribute(HtmlTextWriterAttribute.Src, url); 
        writer.RenderBeginTag(HtmlTextWriterTag.Img); 
        writer.RenderEndTag();
    
        return writer.InnerWriter.ToString();
    }
