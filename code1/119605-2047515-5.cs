    foreach (DataModelObject dmo in allObjects)
    {
        if (dmo is IAgentVersion)
        {
             IAgentVersion = (IAgentVersion)dmo;
             policy.AgentVersion = agentVersion;
        }
    }
