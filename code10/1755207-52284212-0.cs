    if (System.Management.Automation.Runspaces.Runspace.DefaultRunspace == null)
    {
        var defaultRunspace = RunspaceFactory.CreateRunspace();
        defaultRunspace.Open();
        System.Management.Automation.Runspaces.Runspace.DefaultRunspace = defaultRunspace;
    }
