    protected override void Render(HtmlTextWriter writer)
    {
      AddAttributesToRender(writer);
    
      //must render tag or first inner control will get two IDs
      writer.RenderBeginTag(HtmlTextWriterTag.Span);
    
      //render child controls here...
    
      writer.RenderEndTag();
    }
