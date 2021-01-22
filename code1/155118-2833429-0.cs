    writer.AddAttribute(HtmlTextWriterAttribute.Href, string.Concat(Path 1));
    writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/css");
    writer.AddAttribute(HtmlTextWriterAttribute.Rel, "stylesheet");
    writer.RenderBeginTag(HtmlTextWriterTag.Link);
    
    writer.RenderEndTag();
    
    writer.AddAttribute(HtmlTextWriterAttribute.Href, string.Concat(Path 2 ));
    writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/css");
    writer.AddAttribute(HtmlTextWriterAttribute.Rel, "stylesheet");
    writer.RenderBeginTag(HtmlTextWriterTag.Link);
    
    writer.RenderEndTag();
