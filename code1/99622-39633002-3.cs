    var toolsFactory = new SimpleSerializationToolsFactory();
    // Register your config class
    toolsFactory.Configurations.Add(new TestClassConfig());
    
    ExtendedXmlSerializer serializer = new ExtendedXmlSerializer(toolsFactory);
