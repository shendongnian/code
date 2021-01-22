    protected override void Render(HtmlTextWriter writer)
    {
       string tmpOutput;
       var tmpWriter = new HtmlTextWriter(tmpOutput);
       Page.Render(tmpWriter);
       tmpWriter.Flush();
       tmpOutput = DoReplaceLogic(tmpOutput);
       writer.Write(tmpOutput);
    }
