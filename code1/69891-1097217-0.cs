    Dictionary<string, string> resourceMap = new Dictionary<string, string>();
    public static void Func(string fileName)
    {
        ResXResourceReader rsxr = new ResXResourceReader(fileName);        
        foreach (DictionaryEntry d in rsxr)
        {
            resourceMap.Add(d.Key.ToString(),d.Value.ToString());           
        }        
        rsxr.Close();
    }
    public string GetResource(string resourceId)
    {
        return resourceMap[resourceId];
    }
