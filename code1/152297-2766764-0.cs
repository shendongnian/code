    public Attrib DetermineAttribution(Data data)
    {
        var c = data.actions.FirstOrDefault(c => c.actionType == Action.ActionTypeOne
                                              || c.actionType == Action.ActionTypeTwo);
        
        return c != null ? new Attrib { id = c.id, name = c.name }; : null;
    }
