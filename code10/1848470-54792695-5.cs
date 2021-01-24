    var serializer = new XmlSerializer(typeof(LogProperties));
    
    LogProperties logProperties = new LogProperties() 
    { 
        SourceContext = "MySourceContext",
    	ActionId = "MyActionId",
    	ActionName = "MyActionName"
    };
    
    StringBuilder sb = new StringBuilder();
    using (StringWriter writer = new StringWriter(sb))
    {
    	serializer.Serialize(writer, logProperties);
    }
    
    Console.WriteLine(sb.ToString());
