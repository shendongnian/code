    public void Execute(IPluginExecutionContext context)
    {
        string state = (string)context.InputParameters["State"];
        if (state == "Open")
        {
            Moniker entityMoniker = (Moniker)context.InputParameters["EntityMoniker"];
            DynamicEntity opp = new DynamicEntity("opportunity");
            opp["opportunityid"] = new Key(entityMoniker.Id);
            opp["salesstagecode"] = new Picklist(/*your value*/);
            context.CreateCrmService(true).Update(opp);
        }
    }
