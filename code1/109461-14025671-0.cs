    protected override void Render(HtmlTextWriter writer)
    {
            StringBuilder sb = new StringBuilder("<!DOCTYPE HTML>" + Environment.NewLine);
            HtmlTextWriter textWriter = new HtmlTextWriter(new StringWriter(sb));
            base.Render(textWriter);
            writer.Write(sb.ToString());
        }
