    HashSet<string> scriptReferences = new HashSet<string>();
    HashSet<string> cssReferences = new HashSet<string>();
    List<string> styles = new List<string>();
    public void AddScriptReference(string url, bool resolve)
    {
        string realUrl = url;
        if (resolve)
            realUrl = ResolveClientUrl(url);
        if (!scriptReferences.Contains(realUrl))
        {
            scriptReferences.Add(realUrl);
            Header.Controls.Add(
                new LiteralControl(
                    "<script type='text/javascript' src='" +
                    realUrl + "'></script>"));
        }
    }
    public void AddCssReference(string url)
    {
        if (!cssReferences.Contains(url))
        {
            cssReferences.Add(url);
            HtmlLink link = new HtmlLink();
            //link.Href = ResolveClientUrl("~/jQuery-ui/css/ui-lightness/jquery-ui.css");
            link.Href = url;
            link.Attributes.Add("type", "text/css");
            link.Attributes.Add("rel", "stylesheet");
            Header.Controls.Add(link);
        }
    }
    public void AddCssStyle(string style)
    {
        styles.Add(style);
    }
    protected override void OnPreRenderComplete(EventArgs e)
    {
        base.OnPreRenderComplete(e);
        Header.Controls.Add(
            new LiteralControl(
                "<style type='text/css'>" + styles.Join("\n") + "</style>"
            )
        );
    }
    public static void AddScript(HtmlTextWriter writer, string script,
        bool executeWhenReady)
    {
        writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
        writer.RenderBeginTag(HtmlTextWriterTag.Script);
        if (executeWhenReady)
        {
            writer.Write("$(function(){\n");
        }
        writer.Write(script);
        if (executeWhenReady)
        {
            writer.Write("});\n");
        }
        writer.RenderEndTag();
    }
