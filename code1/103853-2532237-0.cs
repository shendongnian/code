    protected override void Render(HtmlTextWriter writer)
    {
		if (this.Controls.Count > 0)
			base.Render(writer); // render in normal way
		else
		{
			writer.Write(HtmlTextWriter.TagLeftChar + this.TagName); // render opening tag
			Attributes.Render(writer); // Add the attributes.  
			writer.Write(HtmlTextWriter.SelfClosingTagEnd); // render closing tag	
		}
		writer.Write(Environment.NewLine); // make it one per line
    }
