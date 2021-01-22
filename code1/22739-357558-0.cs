    class ConnectionStringProvider
    {
        Dictionary<string, System.Configuration.ConnectionStringSettings> _localStrings = new Dictionary<string, System.Configuration.ConnectionStringSettings>();
        public void AddLocalConnectionString(string name, string connstring)
        {
            System.Configuration.ConnectionStringSettings cs = new System.Configuration.ConnectionStringSettings(name, connstring);
            _localStrings.Add(name, cs);
        }
        public void RemoveLocalConnectionString(string name)
        {
            _localStrings.Remove(name);
        }
        public System.Configuration.ConnectionStringSettings this[string name] {
            get 
            { 
                return _localStrings.ContainsKey(name) ? _localStrings[name] : System.Configuration.ConfigurationManager.ConnectionStrings[name]; 
            }
        }
    }
