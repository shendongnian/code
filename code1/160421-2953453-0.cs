    public void ExportToResx(Dictionary<string,string> resourceDictionary, string fileName)
    {
        using(var writer = new ResXResourceWriter(fileName))
        {
            foreach (var resource in resourceDictionary)
            {
                writer.AddResource(resource.Key, resource.Value);
            }
        }
    }
