    protected void Page_Load(object sender, EventArgs e)
    {
        if (System.Diagnostics.Debugger.IsAttached)
        {
            ScriptManager.RegisterClientScriptInclude(this, this.GetType(), "JQueryScript", "resources/jquery-1.3.2.js");
        }
        else
        {
            ScriptManager.RegisterClientScriptInclude(this, this.GetType(), "JQueryScript", "resources/jquery-1.3.2.min.js");
        }
    }
