    protected override void Render(HtmlTextWriter writer)
    {
      AddAttributesToRender(writer);
    
      //must render starting tag or hidden field will get two IDs
      writer.RenderBeginTag(HtmlTextWriterTag.Span);
    
      //render child controls
    
      writer.RenderEndTag();
    }
