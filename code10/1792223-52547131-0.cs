    protected void Page_Init(object sender, EventArgs e)
    {
        var link = new HtmlLink();
        link.Href = "~/styles/main.css";
        link.Attributes.Add("rel", "stylesheet");
        link.Attributes.Add("type", "text/css");
        Page.Body.Controls.Add(link);
    }
