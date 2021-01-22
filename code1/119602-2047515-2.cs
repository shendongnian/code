    foreach (DataModelObject dmo in allObjects)
    {
        if (dmo is IAgentVersion)
        {
             IAgentVersionpolicy = (IAgentVersion)dmo;
             policy.AgentVersion = agentVersion;
        }
    }
