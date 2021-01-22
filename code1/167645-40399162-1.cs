    `protected override void OnInit(EventArgs e)
    {
    
    base.OnInit(e);
    string css = "<link href=\"" + Page.ClientScript.GetWebResourceUrl(this.GetType(),
    "YourProjectName.Assets.Plugins.Dropzone.dist.dropzone.css") + "\" type=\"text/css\" rel=\"stylesheet\" />";
    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "cssFile", css, false);
    ClientScriptManager csm = Page.ClientScript;
    csm.RegisterClientScriptResource(GetType(), "YourProjectName.Assets.Plugins.Dropzone.dist.dropzone.js");
    }
`
