    writer.AddAttribute(HtmlTextWriterAttribute.Id, "someId");
    if (!string.IsNullOrEmpty(cssClass)) writer.AddAttribute(HtmlTextWriterAttribute.Class, cssClass);
    writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "Red");
    writer.RenderBeginTag(HtmlTextWriterTag.Span);
    writer.WriteEncodedText(text);
    writer.RenderEndTag();
