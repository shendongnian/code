    protected override void OnPreRender(EventArgs e)
    {
    	base.OnPreRender(e);
    	ValueLinkButton tempLink = new ValueLinkButton(); // [CASE 2]        
    	tempLink.ID = "valueLinkButton"; // Not persisted to ViewState
    	Controls.Clear();
    	Controls.Add(tempLink);
    	tempLink.Value = "new value";  // Persisted to ViewState
    	tempLink.Text = "Click";       // Persisted to ViewState
    }
