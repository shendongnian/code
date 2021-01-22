    protected override void Render(HtmlTextWriter writer)
    {
    	if (Page != null)
    	{
    		Page.VerifyRenderingInServerForm(this);
    	}
    	base.Render(writer);
    }
