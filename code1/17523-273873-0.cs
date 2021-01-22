    HtmlInputCheckBox box = new HtmlInputCheckBox();
    StringBuilder sb = new StringBuilder();
    using(StringWriter sw = new StringWriter(sb))
    using(HtmlTextWriter htw = new HtmlTextWriter(sw))
    {
        box.RenderControl(htw);
    }
    string html = sb.ToString();
