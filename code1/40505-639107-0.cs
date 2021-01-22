	protected override void OnPreRender(EventArgs e)
	{
		base.OnPreRender(e);
		int count = 0;
		this.disableControls(this, ref count);
	}
    void disableControls(Control control, ref int count)
    {
    	foreach (Control c in control.Controls)
    	{
    		WebControl wc = c as WebControl;
    
    		if (wc != null)
    		{
    			count++;
    			wc.Enabled = false;				
    		}
    
    		this.disableControls(c, ref count);
    	}
    }
