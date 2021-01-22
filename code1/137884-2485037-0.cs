    class ParameterUpdate
    {
        public ParameterUpdate(string name, string value, Action<string> callback)
        {
            this.Name = name;
            this.Value = value;
            this.Callback = callback;
        }
        public string Name { get; private set; }
        public string Value { get; set; }
        public Action<string> Callback { get; private set; }
    }
