    String clientScriptName = "ButtonClickScript";
    Type clientScriptType = this.GetType ();
    
    // Get a ClientScriptManager reference from the Page class.
    ClientScriptManager clientScript = Page.ClientScript;
    
    // Check to see if the client script is already registered.
    if (!clientScript.IsClientScriptBlockRegistered (clientScriptType, clientScriptName))
        {
         StringBuilder sb = new StringBuilder ();
         sb.Append ("<script type='text/javascript'>");
         sb.Append ("window.open(' " + url + "')"); //URL = where you want to redirect.
         sb.Append ("</script>");
         clientScript.RegisterClientScriptBlock (clientScriptType, clientScriptName, sb.ToString ());
         }
