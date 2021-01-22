    StringBuilder sb = new StringBuilder();
    using (HtmlTextWriter w = new HtmlTextWriter(new StringWriter(sb)))
    {
          w.RenderBeginTag(HtmlTextWriterTag.P);
          w.AddStyleAttribute(HtmlTextWriterStyle.Color, "red");
          w.RenderBeginTag(HtmlTextWriterTag.Span);
          w.Write("This is some text");
          w.RenderEndTag();
          w.RenderEndTag();
     }
     string html = sb.ToString();
