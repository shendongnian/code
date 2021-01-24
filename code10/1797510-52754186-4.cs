    public class Config2
    {
        [JsonExtensionData]
        public IDictionary<string, JToken> _config2;
    }
    public class Config
    {
        [JsonExtensionData]
        public IDictionary<string, JToken> _config;
    }
    public class Agent
    {
        [JsonExtensionData]
        public IDictionary<string, JToken> _agents;
    }
    public class AgentRegistry
    {
        public List<Agent> agents { get; set; }
    }
    public class RootObj
    {
        public AgentRegistry agentRegistry { get; set; }
    }
