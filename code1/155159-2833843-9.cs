    protected override void OnPreRender(EventArgs e)
    {
    
        if (!this.DesignMode)
        {
    
            // Link the script up with the script manager
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            if (scriptManager != null)
            {
                scriptManager.RegisterScriptControl(this);
                scriptManager.RegisterScriptDescriptors(this);
                scriptManager.Scripts.Add(new ScriptReference(
                    "Project.Controls.MyDateTimePicker.js", "Project"));
            }
            else
            {
                throw new ApplicationException("You must have a ScriptManager on the Page.");
            }
    
        }
    
        base.OnPreRender(e);
    
    }
