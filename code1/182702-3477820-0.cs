    String csName = "myScript";
    Type csType = this.GetType();
    
    // Get a ClientScriptManager reference from the Page class.
    ClientScriptManager cs = Page.ClientScript;
    
    // Check to see if the client script is already registered.
    if (!cs.IsClientScriptBlockRegistered(csType, csName))
    {
      StringBuilder csText = new StringBuilder();
      csText.Append("<script type=\"text/javascript\"> ");
      csText.Append("addTab(" + myTabID + ", " + myTabList + "); </");
      csText.Append("script>");
      cs.RegisterClientScriptBlock(csType, csName, csText.ToString());
    }
