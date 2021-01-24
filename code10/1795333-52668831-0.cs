    public SystemStatus Get()
    {
        XDocument xmlDoc = XDocument.Parse(xmlData); 
        string jsonStr = JsonConvert.SerializeXNode(xmlDoc);
        dynamic dynamicObject = JsonConvert.DeserializeObject<ExpandoObject>(jsonStr);
        return dynamicObject;
    }
