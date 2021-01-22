    protected void Page_Load(object sender, EventArgs e)
    {
    #if DEBUG    
        ScriptManager.RegisterClientScriptInclude(this, this.GetType(), "JQueryScript", "resources/jquery-1.3.2.js");
        #else
        ScriptManager.RegisterClientScriptInclude(this, this.GetType(), "JQueryScript", "resources/jquery-1.3.2.min.js");
        #endif
    }
