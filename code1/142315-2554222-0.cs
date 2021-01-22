    public void Execute(IPluginExecutionContext context)
    {
        if (context.InputParameters.Properties.Contains("Target") &&
            context.InputParameters.Properties["Target"] is DynamicEntity)
        {
            DynamicEntity opp = (DynamicEntity)context.InputParameters["Target"];
            opp["salesstagecode"] = new Picklist(200004);
        }
    }
