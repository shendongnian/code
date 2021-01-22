    protected string ControlToHtml(Control c)
    {
        StringWriter sw = new StringWriter();
        HtmlTextWriter htmlWriter = new HtmlTextWriter(sw);
        c.RenderControl(htmlWriter);
        return sw.ToString();
    }
