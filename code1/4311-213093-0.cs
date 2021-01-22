    public override void RenderBeginTag(HtmlTextWriter writer) {
      base.RenderBeginTag(writer);
      if (this.TextMode == TextBoxMode.MultiLine) {
        writer.Write("\r\n"); // or Environment.NewLine
      }
    }
