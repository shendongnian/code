    class SomeClass
    {
        JObject configInfo;
        string ServerName;
        public SomeClass()
        {
            configInfo = JObject.Parse(File.ReadAllText("config.json"));
            ServerName = (string)configInfo["servername"];
        }
    }
