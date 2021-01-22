    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        if(_req != null)
            _req.RenderControl(writer);
        base.Render(writer);
    }
