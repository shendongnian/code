    public Attrib DetermineAttribution(Data data)
    {
        return data.actions.Where( c => c.actionType == Action.ActionTypeOne)
                  .Concat( data.actions.Where( c.actionType == Action.ActionTypeTwo )
                  .Select( c => new Attrib
                             {
                                 id = c.id,
                                 name = c.name
                             })
                  .FirstOrDefault();
  }
