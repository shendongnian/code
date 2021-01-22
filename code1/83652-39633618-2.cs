    var serializer = new ConfigurationContainer().UseOptimizedNamespaces().Create();
    var obj = new Example
    				{
    					Model = new Model { Name = "name" }
    				};
    var xml = serializer.Serialize(obj);
