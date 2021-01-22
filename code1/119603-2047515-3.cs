    foreach (DataModelObject dmo in allObjects)
    {
        if (dmo is IResourcePolicy)
        {
             IResourcePolicy policy = (IResourcePolicy)dmo;
             policy.AgentVersion = agentVersion;
        }
    }
