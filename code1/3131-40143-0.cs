    public void RegisterControlClientID(Control control)
    {
       string variableDeclaration = string.Format("var {0} = \"{1}\";", control.ID, control.ClientID);
       ClientScript.RegisterClientScriptBlock(GetType(), control.ID, variableDeclaration, true);
    }
