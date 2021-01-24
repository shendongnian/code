    public override Task TokenEndpoint(OAuthTokenEndpointContext context)
    {
        foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
        {
            if(property.Key == ".expires")
                 context.AdditionalResponseParameters.Add(property.Key, property.Value);
        }
    
        return Task.FromResult<object>(null);
    }
