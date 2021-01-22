    public NameValueCollection CustomProperies { get; set; }
        public PluginConfigurationElement()
        {
            this.CustomProperties = new NameValueCollection();
        }
        protected override bool OnDeserializeUnrecognizedElement(string elementName, XmlReader reader)
        {
            this.CustomProperties.Add(elementName, reader.ReadString());
            return true;
        }
