    public class Agent
    {
        public string Version
        {
            get
            {
                using (var regkey = Registry.LocalMachine.OpenSubKey(SpecialRegistry.SpecialAgentRoot))
                    return (string)regkey.GetValue("CurrentVersion");
            }
        }
    }
