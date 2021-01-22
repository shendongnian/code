    using System.IO;
    ...
    
    protected string RenderLink(object h)
    {
      StringWriter sw = new StringWriter();
      HtmlTextWriter htmlWriter = new HtmlTextWriter(sw);
      HyperLink link = (HyperLink)h;
      link.RenderControl(htmlWriter);
      return sw.ToString();
    }
