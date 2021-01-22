    protected override void Render(HtmlTextWriter writer)
    {
        customers.RenderControl(writer);
        writer.Write("<br />");
        machines.RenderControl(writer);
        writer.Write("<br />");
        specsOutput.RenderControl(writer);
    }
