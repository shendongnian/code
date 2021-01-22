        List<Instance> instances = new List<Instance>();
        // Get your instances here...
        var baseNode = new XElement("Instances");
        instances.ForEach(instance => baseNode.Add("Instance",
            new XAttribute("DatabaseHostname", instance.DatabaseHostname),
            new XAttribute("AccessManagerHostname", instance.AccessManagerHostname),
            new XAttribute("DatabaseUsername", instance.DatabaseUsername),
            new XAttribute("DatabasePassword", instance.DatabasePassword)));
