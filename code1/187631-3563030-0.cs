    private void RegisterClientStartupScript()
    {
        string path = Page.ResolveUrl("~/Script/slider.js");
        ScriptManager sManager = ScriptManager.GetCurrent(this.Page);
        if (sManager != null && sManager.IsInAsyncPostBack)
        {            
            ScriptManager.RegisterClientScriptInclude(
               this.updSpeech, typeof(string),"include-js",
               path);            
        }
        else
        {
            this.Page.ClientScript.RegisterClientScriptInclude("SliderScript", path);
        }
    }    
