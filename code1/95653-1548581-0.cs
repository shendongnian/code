    string html;
    using (StringWriter stream = new StringWriter()) {
       using (HtmlTextWriter writer = new HtmlTextWriter(stream)) {
          base.Render(writer);
       }
       html = stream.ToString();
    }
    Response.Write(html);
    Response.End();
