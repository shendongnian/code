    private string _heldCssClass = null;
    public override void RenderBeginTag(HtmlTextWriter writer)
    {
       writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass);   
       writer.RenderBeginTag("span");
       _heldCssClass = this.CssClass;
       this.CssClass = String.Empty;
       base.RenderBeginTag(writer);
    }
    public override void RenderEndTag(HtmlTextWriter writer)
    {
       writer.RenderEndTag();
       base.RenderEndTag(writer);
       this.CssClass = _heldCssClass;
    }
