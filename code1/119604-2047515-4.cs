    interface IAgentVersion
    {
         string AgentVersion { get; }
         // omit other properties which are not common to all objects
    }
    interface IResourcePolicy : IAgentVersion
    {
         string ResourcePolicy { get; }
         // ...
         // add all policy-specific properties
    }
