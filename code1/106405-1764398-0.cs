    protected override void OnPreRender(EventArgs e)
    {
    
        if (!this.DesignMode)
        {
    
            // Link the script up with the script manager
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            if (scriptManager != null)
            {
                scriptManager.RegisterScriptControl(this);
            }
    
        }
    
        base.OnPreRender(e);
    
    }
    
    protected override void Render(HtmlTextWriter writer)
    {
        if (!this.DesignMode)
        {
            ScriptManager.GetCurrent(this.Page).RegisterScriptDescriptors(this);
        }
        base.Render(writer);
    }
