    PrincipalContext context = null;
    if (credType == 1)
    {
        context = new PrincipalContext(ContextType.Machine, txtSingleServer.Text, txtAltCredID.Text, txtAltCredPW.Text);
    }
    else if (credType == 2)
    {
        context = new PrincipalContext(ContextType.Machine, txtSingleServer.Text);
    }
