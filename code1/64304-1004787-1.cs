    StringWriter stringWriter = new StringWriter();
    using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
    {
        writer.AddAttribute(HtmlTextWriterAttribute.Class, classValue);
        writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #1
        writer.AddAttribute(HtmlTextWriterAttribute.Href, urlValue);
        writer.RenderBeginTag(HtmlTextWriterTag.A); // Begin #2
        writer.AddAttribute(HtmlTextWriterAttribute.Src, imageValue);
        writer.AddAttribute(HtmlTextWriterAttribute.Width, "60");
        writer.AddAttribute(HtmlTextWriterAttribute.Height, "60");
        writer.AddAttribute(HtmlTextWriterAttribute.Alt, "");
        writer.RenderBeginTag(HtmlTextWriterTag.Img); // Begin #3
        writer.RenderEndTag(); // End #3
        writer.Write(word);
        writer.RenderEndTag(); // End #2
        writer.RenderEndTag(); // End #1
    }
    // Return the result.
    return stringWriter.ToString();
