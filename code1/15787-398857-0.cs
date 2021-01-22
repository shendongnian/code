    protected internal override void RenderChildren(HtmlTextWriter writer)
    {
    	Page page = this.Page;
    	if (page != null)
    	{
    		page.OnFormRender();
    		page.BeginFormRender(writer, this.UniqueID);
    	}
    	base.RenderChildren(writer);
    	if (page != null)
    	{
    		page.EndFormRender(writer, this.UniqueID);
    		page.OnFormPostRender();
    	}
    }
